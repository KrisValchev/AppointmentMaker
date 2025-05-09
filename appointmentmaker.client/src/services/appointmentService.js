import axios from "axios";

const API_BASE = "http://localhost:5194/api/AppointmentController";

export function getBusyHours(id)
{
    return axios.get(`${API_BASE}/get-busy-hours/${id}`);
}