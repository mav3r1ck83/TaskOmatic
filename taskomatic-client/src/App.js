import React from "react";
import { Container } from "react-bootstrap";
import TaskList from "./TaskList";

function App() {
  return (
    <Container className="py-4">
      <h2 className="text-center mb-4">🧠 TaskOmatic</h2>
      <TaskList />
    </Container>
  );
}

export default App;
