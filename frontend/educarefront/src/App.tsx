import React, { useState } from 'react';
import logo from './logo.svg';
import  {BrowserRouter,Routes,Route} from "react-router-dom"
import LogIn from './Pages/LogIn';
import Register from './Pages/Register';
import FillAcount from './Pages/FillAcount';
import Profile from './Components/Profile';
import Universitati from './Pages/Universitati';
import { SimpleHeader } from './Components/SimpleHeader';
import PlusButton from "../src/Components/PlusButton"
import { SubjectRow } from './Components/SubjectRow';
import { CreateTest } from './Pages/CreateTest';
function App() {
  const [exerciseNumber, setExerciseNumber] = useState(0)
  return (

    // <BrowserRouter>
    // <Routes>
    //   <Route path='/' element={<LogIn/>} />
    //   <Route path='/register' element={<Register/>}/>
    //   <Route path='/AccountData' element={<FillAcount/>}/>
    //   <Route path="/Profile/:emailrouter" element={<Profile/>}/>

    // </Routes>
    
    // </BrowserRouter>
    // <SimpleHeader text='POO'></SimpleHeader>
    // <PlusButton></PlusButton>
    // <SubjectRow name='asdadsad' exerciseNumber={exerciseNumber} setExerciseNumber ={setExerciseNumber} ></SubjectRow>
    <CreateTest name='POO'></CreateTest>
   
  );
}

export default App;
