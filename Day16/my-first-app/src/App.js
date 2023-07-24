import './App.css';
import ClassButtonTest from './components/ClassButtonTest';
import CustomClassButton from './components/CustomClassButton';
import CustomFunctionButton from './components/CustomFunctionButton';
import FormTest from './components/FormTest';
import FunctionButtonTest from './components/FunctionButtonTest';
import JokeButton from './components/JokeButton';

function App() {

  function saveMessage(message)
  {
    localStorage.setItem('greeting', message);
  }

  return (
    <div className="App">
      <FormTest />
      <br></br>
      <CustomFunctionButton buttonColor='primary' onClick={() => saveMessage('Hello')}>
        Save 'Hello' to local storage
      </CustomFunctionButton>
      <CustomClassButton buttonColor='primary' onClick={() => saveMessage('Hi Class')}>
        Save 'Hi Class' to local storage
      </CustomClassButton>
      <CustomClassButton buttonColor='primary' onClick={() => alert(localStorage.getItem('greeting') ?? 'No message stored')}>
        Read message from local storage
      </CustomClassButton>
      <ClassButtonTest />
      <FunctionButtonTest />
      <JokeButton />

    </div>
  );
}

export default App;