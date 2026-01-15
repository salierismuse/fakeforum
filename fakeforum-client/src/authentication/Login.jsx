import { useState } from 'react';


function LogInForm() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();
    
        const response = await fetch('http://localhost:5287/api/auth/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({  email, password })

        });

        const data = await response.json();
        if (response.ok) {
            // remove
            console.log(data.token);
        }
        else {
            console.log(data.error);
        }
    };
    return (
            <form onSubmit={handleSubmit}>
            <input type="email" value = {email} onChange={(e) => setEmail(e.target.value)} placeholder="Email"/>
            <input type="password" value = {password} onChange={(e) => setPassword(e.target.value)} placeholder="Password"/>\
            <button type="submit">Register!</button>
            </form>
    )

}

export default LogInForm;