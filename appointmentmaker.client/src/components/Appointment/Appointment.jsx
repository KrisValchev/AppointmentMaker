import styles from './Appointment.module.css'
import { getBusyHours, getBarbers, postAppointment, postAppointmentInCalendar } from '../../services/appointmentService.js'
import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import Failure from '../Failure/Failure';
function Appointment({ setHasAccess }) {

    //date convertor
    function convertToISODate(ddmmyyyy) {
        const [day, month, year] = ddmmyyyy.split("-");
        return `${year}-${month}-${day}`;
    }


    // Generate time slots from 08:00 to 18:00 every 30 minutes
    const generateTimeSlots = (startHour, endHour, intervalMinutes) => {
        const options = [];
        const start = new Date();
        start.setHours(startHour, 0, 0, 0);

        const end = new Date();
        end.setHours(endHour, 0, 0, 0);

        while (start <= end) {
            const hours = start.getHours().toString().padStart(2, "0");
            const minutes = start.getMinutes().toString().padStart(2, "0");
            const time = `${hours}:${minutes}`;
            options.push(time);
            start.setMinutes(start.getMinutes() + intervalMinutes);
        }

        return options;
    };
    const timeSlots = generateTimeSlots(8, 18, 30);

    // Load barbers on component mount
    const [barbers, setBarbers] = useState([]);
    const [selectedBarber, setSelectedBarber] = useState('');
    useEffect(() => {
        getBarbers()
            .then((response) => {
                setBarbers(response.data); //the response data is an array of barbers
            })
            .catch((error) => {
                console.error('Error fetching barbers:', error);
            });
    }, []);
    const [selectedBarberText, setSelectedBarberText] = useState("");
    const handleChange = (event) => {
        setSelectedBarber(event.target.value);
        const selectedText = event.target.options[event.target.selectedIndex].text;     
        setSelectedBarberText(selectedText);
    };

    // Load busy hours when barber or date changes
    const [selectedDate, setSelectedDate] = useState('');
    const [busyHours, setBusyHours] = useState([]);
    const [selectedHour, setSelectedHour] = useState('');

    useEffect(() => {
        if (selectedBarber && selectedDate) {
            getBusyHours(selectedBarber, selectedDate)
                .then((res) => {
                    const times = res.data.map(entry => entry.time);
                    setBusyHours(times);
                })
                .catch((err) => console.log('Error fetching busy hours:', err));
        }
    }, [selectedBarber, selectedDate]);

    //Make appointment on submit
    const [clientNames, setClientNames] = useState('');
    const [phoneNumber, setPhoneNumber] = useState('');
    const [description, setDescription] = useState('');
    const navigate = useNavigate();
    const appointment = {
        ClientNames: clientNames,
        Date: selectedDate,
        Time: selectedHour,
        BarberId: selectedBarber,
        Description: description,
        PhoneNumber: phoneNumber
    };

    //Validate form and show errors if needed
    const [errorMessages, setErrorMessages] = useState([]);
    const validateForm = () => {
        const errors = [];
        if (clientNames.length < 2 || clientNames.length > 50) {
            errors.push("Name must be between 2 and 50 characters");

        }

        if (!/^\+?\d{10}$/.test(phoneNumber)) {
            errors.push("Invalid phone number");

        }

        if (description.length > 1000) {
            errors.push("Description is over 1000 characters");

        }

        if (!/^\d{2}-\d{2}-\d{4}$/.test(selectedDate)) {
            errors.push("Date is not in the correct format (dd-mm-yyyy)");

        }
        if (selectedBarber == 0) {
            errors.push("Choose a barber!");
        }
        if (selectedHour.length === 0) {
            errors.push("Choose a time!");
        }
        if (busyHours.includes(selectedHour)) {
            errors.push("There is already an appointment at this time. Choose different time!");
        }
        
        setErrorMessages(errors);
        return errors.length === 0;
    };
    //Show success page after valid form 
    const handleSubmit = async (e) => {
        e.preventDefault();// prevent default form submit behavior
        const isValid = validateForm();
        if (!isValid) return;
        const response = postAppointment(appointment);
        postAppointmentInCalendar({
            clientName: clientNames,
            phone: phoneNumber,
            barberName: selectedBarberText,
            description: description,
            time:selectedHour,
            startTime: convertToISODate(selectedDate),
        });
        setHasAccess(true); 
        navigate('/success', {
            state: {
                selectedDate: selectedDate,
                selectedHour: selectedHour,
                selectedBarber: selectedBarberText
            },

        });


    };

    return (
        <div className="container" >
            <div className={styles["well-block"]}>
                <div className={styles["well-title"]}>
                    <h2>Book an Appointment</h2>
                </div>
                <form>
                    <div className="row">
                        {/* Name */}
                        <div className="col-md-6">
                            <div className="form-group">
                                <label htmlFor="name">Name</label>
                                <input id="name" name="name" type="text" placeholder="Name" className="form-control input-md" value={clientNames}
                                    onChange={(e) => setClientNames(e.target.value)} />
                            </div>
                        </div>

                        {/* Date */}
                        <div className="col-md-6">
                            <div className="form-group">
                                <label htmlFor="date">Preferred date </label>
                                <input id="date" name="date" type="text" placeholder="dd-mm-yyyy" className="form-control input-md" value={selectedDate}
                                    onChange={(e) => setSelectedDate(e.target.value)} />
                            </div>
                        </div>

                        {/* Time */}
                        <div className="col-md-6">
                            <div className="form-group">
                                <label htmlFor="time">Preferred Time</label>
                                <select id="time" name="time" className="form-control" value={selectedHour} onChange={(e) => setSelectedHour(e.target.value)}>
                                    <option value="">Select a time</option>
                                    {timeSlots.map((time, index) => (
                                        <option
                                            key={time}
                                            value={time}
                                            disabled={busyHours.includes(time)}
                                        >
                                            {time} {busyHours.includes(time) ? '(Busy)' : ''}
                                        </option>
                                    ))}
                                </select>
                            </div>
                        </div>
                        {/* Phone number */}
                        <div className="col-md-6">
                            <div className="form-group">
                                <label htmlFor="phoneNumber">Phone Number</label>
                                <input id="phoneNumber" name="phoneNumber" type="text" placeholder="Phone Number" className="form-control input-md" value={phoneNumber}
                                    onChange={(e) => setPhoneNumber(e.target.value)} />
                            </div>
                        </div>
                        {/* Appointment For */}
                        <div className="col-md-12">
                            <div className="form-group">
                                <label htmlFor="appointmentfor">Appointment For</label>
                                <select id="barberDropdown" value={selectedBarber}
                                    onChange={handleChange} className="form-control">
                                    <option value="">Select a Barber</option>
                                    {barbers.map((barber) => (
                                        <option key={barber.id} value={barber.id}>
                                            {barber.name}
                                        </option>
                                    ))}
                                </select>
                            </div>
                        </div>
                        <div className="col-md-12">
                            <div className="form-group">
                                <label htmlFor="comment">Comment for appointment</label>
                                <textarea
                                    className="form-control"
                                    placeholder="Write a comment..."
                                    style={{ resize: "none" }}
                                    value={description} onChange={(e) => setDescription(e.target.value)}
                                />
                            </div>
                        </div>

                        {/* Submit */}
                        <div className="col-md-12">
                            <div className="form-group">
                                <button type="submit" id="singlebutton" name="singlebutton" className="btn btn-default" onClick={handleSubmit}>Make An Appointment</button>
                            </div>
                        </div>
                        {errorMessages.length > 0 && <Failure errorMessages={errorMessages} />}
                    </div>
                </form>
            </div>
        </div>


    );
}

export default Appointment;