import axios from "axios";

const API_BASE = "https://localhost:7024/api/appointment";

export function getBusyHours(id,date)
{
    return  axios.get(`${API_BASE}/get-busy-hours/${id}/${date}`);
}

export function getBarbers() {
    return  axios.get(`${API_BASE}/get-barbers`);
}

export function postAppointment(appointment) {
    return  axios.post(`${API_BASE}/make-appointment`, appointment);
}

export function postAppointmentInCalendar(appointment) {
    return axios.post(`${API_BASE}/create`, appointment);
}