import { useState, useEffect } from 'react';
import api from '../api';
import Task from '../components/Task';
import '../styles/Home.css';

function Home() {
    const [tasks, setTasks] = useState([]);
    const [title, setTitle] = useState('');
    const [description, setDescription] = useState('');

    useEffect(() => {
        getTasks();
    }, []);

    const getTasks = () => {
        api
            .get('/api/tasks/')
            .then((response) => response.data)
            .then((data) => {
                setTasks(data);
                console.log(data);
            })
            .catch((error) => alert(error));
    };

    const deleteTask = (id) => {
        api
            .delete(`/api/tasks/${id}/`)
            .then((res) => {
                if (res.status === 204) {
                    alert('Task deleted successfully');
                } else {
                    alert('Failed to delete Task.');
                }

                getTasks();
            })
            .catch((error) => alert(error));

    };

    const addTask = (e) => {
        e.preventDefault();

        api
            .post('/api/tasks/', { title, description })
            .then((res) => {
                if (res.status === 201) {
                    setTitle('');
                    setDescription('');
                } else {
                    alert('Failed to add Task.');
                }

                getTasks();
            })
            .catch((error) => alert(error));
    };

    return (
        <div>
            <div>
                <h2>Tasks</h2>
                {tasks.map((task) => <Task key={task.id} task={task} onDelete={deleteTask} />)}
            </div>
            <h2>Add a Task</h2>
            <form onSubmit={addTask}>
                <label htmlFor="title">Title:</label>
                <br />
                <input
                    type="text"
                    id="title"
                    name="title"
                    required
                    placeholder="Title"
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}
                />
                <label htmlFor="description">Description:</label>
                <br />
                <textarea
                    id="description"
                    name="description"
                    required
                    placeholder="Description"
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                />
                <br />
                <input type="submit" value="Submit"></input>
            </form>
        </div>
    );
}

export default Home;