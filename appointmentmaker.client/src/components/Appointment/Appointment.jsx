import styles from './Appointment.module.css'
function Appointment() {


    return (
        <div className="container" >    
            <div className={styles["well-block"]}>
                <div className={styles["well-title"]}>
                            <h2>Questions? Book an Appointment</h2>
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
                                            <option value="8:00 to 9:00">8:00 to 9:00</option>
                                            <option value="9:00 to 10:00">9:00 to 10:00</option>
                                            <option value="10:00 to 1:00">10:00 to 1:00</option>
                                        </select>
                                    </div>
                                </div>

                                {/* Appointment For */}
                                <div className="col-md-12">
                                    <div className="form-group">
                                        <label htmlFor="appointmentfor">Appointment For</label>
                                        <select id="appointmentfor" name="appointmentfor" className="form-control">
                                            <option value="Service#1">Service#1</option>
                                            <option value="Service#2">Service#2</option>
                                            <option value="Service#3">Service#3</option>
                                            <option value="Service#4">Service#4</option>
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
                                <button id="singlebutton" name="singlebutton"  className="btn btn-default">Make An Appointment</button>
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            
       
    );
} 

export default Appointment;