import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
function Home() {
    const [boards, setBoards] = useState([]);
    const [loading, setLoading] = useState(true);

     useEffect(() => {
        const fetchBoards = async () => {
            try {
                const response = await fetch('http://localhost:5287/api/board');
                const data = await response.json();
                setBoards(data);
            } catch (err) {
                console.error('Failed to fetch boards:', err);
            }
            setLoading(false);
        };

        fetchBoards();
    }, []);

    if (loading) return <p>Loading...</p>;  

    return (
        <div>
            <h2>BOARDS</h2>
            {boards.map(board => (
                <div key={board.id}>
                    <Link to={`/board/${board.id}`}>
                        <h3>{board.name}</h3>
                        <p>{board.description}</p>
                    </Link>
                </div>
            ))}
            <h2>RECENT POSTS</h2>
        </div>
    )
}

export default Home;