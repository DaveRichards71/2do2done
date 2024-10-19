import react from 'react';
import '../styles/Task.css';


function Task({ task, onDelete }) {
    const formattedDate = new Date(task.created_at).toLocaleString("en-US");
    return (
        <div className="task-container">
            <p className="task-title">{task.title}</p>
            <p className="task-description">{task.description}</p>
            <p className="task-date">{formattedDate}</p>
            <p className="task-name">{task.assigned_to}</p>
            <button className="delete-button" onClick={() => onDelete(task.id)}>Delete</button>
        </div>
    );
}

export default Task;