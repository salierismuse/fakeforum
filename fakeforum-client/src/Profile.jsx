import { useState } from 'react';
import { useParams } from 'react-router-dom';

function Profile() {
    const { username } = useParams();
    const [profile, setProfile] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    const handleSubmit = async (e) => {
            e.preventDefault();
            setError('');
        try {
            const response = await fetch(`http://localhost:5287/api/user/${username}`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ username })
            });

            const data = await response.json();
            setProfile(data);

        } catch (err) {
            console.error('Profile error:', err);
        }
        if (loading) return <p>Loading...</p>

        if (error) return <p style={{ color: 'red' }}>{error}</p>

        return (
            <div>
                <img src={profile.avatarUrl} alt="Avatar" />
                <h1>{profile.username}</h1>
                <p>{profile.bio}</p>
            </div>
        )

    };

}

export default Profile;