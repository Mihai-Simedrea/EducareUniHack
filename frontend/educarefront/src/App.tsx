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
import { Blanks } from './Components/Blanks';
import DropdownList from './Components/DropdownList';
import { Poo } from './Pages/Poo';
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
      <Route path="/Curs" element={<Poo></Poo>}/>
      <Route path="/Blanks" element={<Blanks curs='O ierarhie este o clasificare sau o ordonare a abstractiunilor. Programarea orientata pe obiecte este o metoda de implementare a programelor. In care acestea sunt organizate ca si colectii de obiecte care coopereaza ıntre ele. Fiecare obiect reprezentand instanta unei clase. Fiecare clasa fiind membra unei ierarhii de clase ce sunt unite prin relatii de mostenire.'></Blanks>}/>
    </Routes>
    
    </BrowserRouter>
    );
}

export default App;
