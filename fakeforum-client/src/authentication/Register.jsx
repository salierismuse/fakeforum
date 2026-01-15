import { useState } from 'react';


function RegisterForm() {
    const [username, setUsername] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [bio, setBio] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();

        const response = await fetch('http://localhost:5287/api/auth/register', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username, email, password, bio })
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
            <input type="text" value = {username} onChange={(e) => setUsername(e.target.value)} placeholder="Username"/>
            <input type="password" value = {password} onChange={(e) => setPassword(e.target.value)} placeholder="Password"/>
            <input type="email" value = {email} onChange={(e) => setEmail(e.target.value)} placeholder="Email"/>
            <input type="text" value = {bio} onChange={(e) => setBio(e.target.value)} placeholder="Bio"/>
            <button type="submit">Register!</button>
        </form>
    );
    
}

export default RegisterForm;