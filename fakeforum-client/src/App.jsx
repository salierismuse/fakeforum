import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import { BrowserRouter, Routes, Route, Link } from 'react-router-dom';
import RegisterForm from './authentication/Register';
import LogInForm from './authentication/Login';
import Header from './Header';
import { AuthProvider } from './authentication/AuthContext';
import Profile from './Profile';
import Home from './Home';
import Board from './Board';

function App() {
  return (
    <AuthProvider>
      <BrowserRouter>
        <Header />

        
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<LogInForm />} />
          <Route path="/register" element={<RegisterForm />} />
          <Route path="/profile/:username" element={<Profile />} />
          <Route path="/board/:id" element={<Board />} />
        </Routes>
      </BrowserRouter>
    </AuthProvider>
  );
}

export default App;