import { useEffect, useState } from 'react';
import './App.css';
import { Routes, Route, Navigate } from 'react-router-dom';
import Success from './components/Success/Success';
import Appointment from './components/Appointment/Appointment';
function App() {
    const [hasAccess, setHasAccess] = useState(false);
    return (
        <Routes>
            <Route path="/" element={<Appointment setHasAccess={setHasAccess} />} />
            <Route path="/appointment" element={<Appointment setHasAccess={setHasAccess} />} />
            <Route path="/success" element={hasAccess ? <Success /> : <Navigate to="/"/>} />
        </Routes>
    );
    
}

export default App;