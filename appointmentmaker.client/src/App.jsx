import { useEffect, useState } from 'react';
import './App.css';
import { Routes, Route } from 'react-router-dom';
import Success from './components/Success/Success';
import Appointment from './components/Appointment/Appointment';
function App() {
    return (
        <Routes>
            <Route path="/" element={<Appointment />} />
            <Route path="/appointment" element={<Appointment />} />
            <Route path="/success" element={<Success/>} />
        </Routes>
    );
    
}

export default App;