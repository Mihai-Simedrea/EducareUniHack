import React, { useState } from 'react';
import logo from './logo.svg';
import  {BrowserRouter,Routes,Route} from "react-router-dom"
import LogIn from './Pages/LogIn';
import Register from './Pages/Register';
import FillAcount from './Pages/FillAcount';
import Profile from './Components/Profile';
<<<<<<< Updated upstream
import { SimpleHeader } from './Components/SimpleHeader';
=======
>>>>>>> Stashed changes
import PlusButton from "../src/Components/PlusButton"
import { SubjectRow } from './Components/SubjectRow';
import { CreateTest } from './Pages/CreateTest';
import {SearchPage} from "./Pages/SearchPage";
function App() {
  const [exerciseNumber, setExerciseNumber] = useState(0)
  return (

    <BrowserRouter>
    <Routes>
      <Route path='/' element={<LogIn/>} />
      <Route path='/register' element={<Register/>}/>
      <Route path='/AccountData' element={<FillAcount/>}/>
<<<<<<< Updated upstream
      <Route path="/Profile/:emailrouter" element={<Profile/>}/>
      <Route path="/search" element={<SearchPage/>}></Route>
=======
      <Route path="/Profile/:uid" element={<Profile/>}/>
>>>>>>> Stashed changes

    </Routes>
    
<<<<<<< Updated upstream
    </BrowserRouter>
    // <SimpleHeader text='POO'></SimpleHeader>
    // <PlusButton></PlusButton>
    // <SubjectRow name='asdadsad' exerciseNumber={exerciseNumber} setExerciseNumber ={setExerciseNumber} ></SubjectRow>
    //<CreateTest name='POO'></CreateTest>
=======
    // </BrowserRouter>
>>>>>>> Stashed changes
   
  );
}

export default App;
