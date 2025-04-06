import React, { useEffect, useState } from "react";
import { Table, Button, Dropdown, Form, Spinner } from "react-bootstrap";
import axios from "axios";

const TaskList = () => {
  const [tasks, setTasks] = useState([]);
  const [users, setUsers] = useState([]);
  const [editingTaskId, setEditingTaskId] = useState(null);
  const [loading, setLoading] = useState(true);

  // Fetch tasks and users
  useEffect(() => {
    const fetchData = async () => {
      try {
        const [taskRes, userRes] = await Promise.all([
          axios.get("/api/tasks"),
          axios.get("/api/users"),
        ]);
  
        // 🐞 Debug
        console.log("Fetched users:", userRes.data);
  
        // Extract tasks
        const taskList = Array.isArray(taskRes.data.tasks)
          ? taskRes.data.tasks
          : Array.isArray(taskRes.data)
          ? taskRes.data
          : [];
  
        // ✅ Correctly extract `userDtos`
        const userList = Array.isArray(userRes.data.userDtos)
          ? userRes.data.userDtos
          : [];
  
        setTasks(taskList);
        setUsers(userList);
        setLoading(false);
      } catch (error) {
        console.error("Error loading data:", error);
        setLoading(false);
      }
    };
  
    fetchData();
  }, []);
  

  const handleAddTask = async () => {
    try {
      const res = await axios.post("/api/tasks", {
        name: "",
        description: "",
        userId: null,
      });

      const newTask = {
        id: res.data,
        name: "",
        description: "",
        userID: null,
      };

      const current = Array.isArray(tasks) ? tasks : [];
      setTasks([...current, newTask]);
      setEditingTaskId(res.data);
    } catch (error) {
      console.error("Error creating task:", error);
    }
  };

  const handleUpdate = async (taskId, updatedTask) => {
    if (!taskId) return; // avoid PUT without id
    await axios.put(`/api/tasks/${taskId}`, updatedTask);

  };

  const handleDelete = async (taskId) => {
    await axios.delete(`/api/tasks/${taskId}`);
    setTasks((prev) => prev.filter((t) => t.id !== taskId));
  };

  const handleChange = (taskId, field, value) => {
    const updatedTasks = tasks.map((task) =>
      task.id === taskId ? { ...task, [field]: value } : task
    );
    setTasks(updatedTasks);

    const updated = updatedTasks.find((t) => t.id === taskId);
    handleUpdate(taskId, updated);
  };

  if (loading) {
    return <Spinner animation="border" className="d-block mx-auto mt-5" />;
  }

  return (
    <div>
      {tasks.length > 0 ? (
        <Table striped bordered hover responsive>
          <thead>
            <tr>
              <th>Action</th>
              <th>Name</th>
              <th>Description</th>
              <th>Assigned To</th>
            </tr>
          </thead>
          <tbody>
            {tasks.map((task) => {
              const isEditing = editingTaskId === task.id;
              return (
                <tr key={task.id}>
                  <td>
                    <Dropdown>
                      <Dropdown.Toggle variant="secondary" size="sm" />
                      <Dropdown.Menu>
                        <Dropdown.Item onClick={() => setEditingTaskId(task.id)}>
                          Edit
                        </Dropdown.Item>
                        <Dropdown.Item
                          onClick={() => handleDelete(task.id)}
                          className="text-danger"
                        >
                          Delete
                        </Dropdown.Item>
                      </Dropdown.Menu>
                    </Dropdown>
                  </td>

                  <td>
                    {isEditing ? (
                      <Form.Control
                        type="text"
                        value={task.name}
                        onChange={(e) =>
                          handleChange(task.id, "name", e.target.value)
                        }
                      />
                    ) : (
                      task.name
                    )}
                  </td>

                  <td>
                    {isEditing ? (
                      <Form.Control
                        type="text"
                        value={task.description}
                        onChange={(e) =>
                          handleChange(task.id, "description", e.target.value)
                        }
                      />
                    ) : (
                      task.description
                    )}
                  </td>

                  <td>
                    {isEditing ? (
                      <Form.Select
                        value={task.userID || ""}
                        onChange={(e) =>
                          handleChange(
                            task.id,
                            "userID",
                            e.target.value === "" ? null : parseInt(e.target.value)
                          )
                        }
                      >
                        <option value="">Unassigned</option>
                        {Array.isArray(users) &&
                          users.map((user) => (
                            <option key={user.id} value={user.id}>
                              {user.firstName} {user.lastName}
                            </option>
                          ))}
                      </Form.Select>
                    ) : (
                      users.find((u) => u.id === task.userID)?.firstName || "Unassigned"
                    )}
                  </td>
                </tr>
              );
            })}
          </tbody>
        </Table>
      ) : (
        <p className="text-center text-muted">No tasks yet. Start by adding one!</p>
      )}

      <div className="d-flex justify-content-center mt-3">
        <Button variant="primary" onClick={handleAddTask}>
          ➕ Add Task
        </Button>
      </div>
    </div>
  );
};

export default TaskList;
