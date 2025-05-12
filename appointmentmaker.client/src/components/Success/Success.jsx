import { useLocation } from 'react-router-dom';
function Success() {
    const location = useLocation();
    const { selectedDate, selectedHour, selectedBarber } = location.state || {};
    return (<div className="alert alert-success" role="alert">
        <h4 className="alert-heading">Thank you for the appointment!</h4>
        <p>You succesfully made an appointment for {selectedDate} {selectedHour} with {selectedBarber}</p>
    </div>
    )
}
export default Success;