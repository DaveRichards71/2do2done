import './App.css';

function App() {
  return (
    <div className="App">
      <AddItem />
    </div>
  );
}

function AddItem() {
  return (
    <form>
      <label for="name">Name:</label>
      <input type="text" name="name" id="name" />
    </form>
  );
}

export default App;
