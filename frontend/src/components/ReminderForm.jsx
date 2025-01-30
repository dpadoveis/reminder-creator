import { useState } from "react";
import Button from "./ui/Button";

function ReminderForm({ onAddReminder }) {
  const [name, setName] = useState("");
  const [date, setDate] = useState("");

  const getTodayDate = () => {
    return new Date().toISOString().split("T")[0];
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!name || !date) {
      alert("Preencha todos os campos!");
      return;
    }
    if (date < getTodayDate()) {
      alert("A data não pode ser anterior à data atual!");
      return;
    }
  
    onAddReminder(name, date);
    setName("");
    setDate("");
  };

  return (
    <div className="reminder-form">
      <h2>Criador de lembretes</h2>
      <h3>Insira aqui o nome do lembrete que deseja criar:</h3>
      <input
        type="text"
        placeholder="Nome do lembrete"
        value={name}
        onChange={(e) => setName(e.target.value)}
        className="input"
      />
      <h3>Escolha a data do acontecimento:</h3>
      <input
        type="date"
        value={date}
        onChange={(e) => setDate(e.target.value)}
        className="input"
        placeholder="Data do lembrete"
      />
      <Button onClick={handleSubmit} className="btn-create">Criar</Button>
    </div>
  );
}

export default ReminderForm;
