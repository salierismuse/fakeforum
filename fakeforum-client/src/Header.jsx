import { useAuth } from './authentication/AuthContext';
import Profile from './Profile';

function Header() {
    const { user, loading, logout } = useAuth();

    if (loading) return <nav>Loading...</nav>;

    return (
        <nav>
            <a href="/" >FakeForum</a>
            {user ? (
                <>
                <a href={`/profile/${user.username}`}>{user.username}</a>
                <button onClick={logout}>Logout</button>
                <a href={`/profile/${user.username}`}>My Profile</a>
                </>
            ) : (
                <>
                    <a href="/login">Login</a>
                    <a href="/register">Register</a>
                    
                </>
            )}
        </nav>
    );
}

export default Header;