import styles from './Appointment.module.css'
import { getBusyHours } from '../../services/appointmentService.js'
import { getBarbers } from '../../services/appointmentService.js'
import React, { useState, useEffect } from 'react';
function Appointment() {
    //generating time spans
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

    // generating barbers
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
    const handleChange = (event) => {
        setSelectedBarber(event.target.value);
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
                                <input id="name" name="name" type="text" placeholder="Name" className="form-control input-md" />
                            </div>
                        </div>

                        {/* Date */}
                        <div className="col-md-6">
                            <div className="form-group">
                                <label htmlFor="date">Preferred Date</label>
                                <input id="date" name="date" type="text" placeholder="Preferred Date" className="form-control input-md" />
                            </div>
                        </div>

                        {/* Time */}
                        <div className="col-md-6">
                            <div className="form-group">
                                <label htmlFor="time">Preferred Time</label>
                                <select id="time" name="time" className="form-control">
                                    {timeSlots.map((time, index) => (
                                        <option key={index} value={time}>
                                            {time}
                                        </option>
                                    ))}
                                </select>
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
                                />
                            </div>
                        </div>

                        {/* Submit */}
                        <div className="col-md-12">
                            <div className="form-group">
                                <button id="singlebutton" name="singlebutton" className="btn btn-default" >Make An Appointment</button>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>


    );
}

export default Appointment;