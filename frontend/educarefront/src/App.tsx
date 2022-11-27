import React, { useState } from 'react';
import logo from './logo.svg';
import  {BrowserRouter,Routes,Route} from "react-router-dom"
import LogIn from './Pages/LogIn';
import Register from './Pages/Register';
import FillAcount from './Pages/FillAcount';
import Profile from './Components/Profile';
import { Home } from './Pages/Home';
import {SearchPage} from "./Pages/SearchPage";
import PageWithField from './Pages/PageWithFields';
function App() {
  const [exerciseNumber, setExerciseNumber] = useState(0)
  return (

    <BrowserRouter>
    <Routes>
      <Route path='/' element={<LogIn/>} />
      <Route path='/register' element={<Register/>}/>
      <Route path='/AccountData' element={<FillAcount/>}/>
      <Route path="/Profile/:emailrouter" element={<Profile/>}/>
      <Route path="/search" element={<SearchPage/>}></Route>
      <Route path='/Home' element={<Home/>}/>
      <Route path="/Profile/:uid" element={<Profile/>}/>
      <Route path="/Field/:unid" element={<PageWithField/>}/>
      <Route path="/Degree/:did" element={<></>}/>
    </Routes>
    
    </BrowserRouter>
    
  );
}

export default App;
