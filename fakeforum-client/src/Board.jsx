import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { useParams } from 'react-router-dom';
function Board() {
    const { id } = useParams();
    const [board, setBoard] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);


    useEffect(() => {
        const fetchBoard = async () => {
        try {
            const response = await fetch(`http://localhost:5287/api/board/${id}`);
                const data = await response.json();
                setBoard(data);
        } catch (err) {
            console.error('Board error:', err);
        }
        setLoading(false);
    };
    fetchBoard();
    }, [id]);

    if (loading) return <p>Loading...</p>

    if (error) return <p style={{ color: 'red' }}>{error}</p>


    return (
        <div>
            <h2>{board?.name}</h2>
            <p>{board?.description}</p>
            <h3>Posts</h3>
        </div>
    )
}

export default Board;