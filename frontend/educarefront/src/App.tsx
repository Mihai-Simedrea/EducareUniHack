import React, { useState } from 'react';
import logo from './logo.svg';
import  {BrowserRouter,Routes,Route} from "react-router-dom"
import LogIn from './Pages/LogIn';
import Register from './Pages/Register';
import FillAcount from './Pages/FillAcount';
import Profile from './Components/Profile';
import { Home } from './Pages/Home';
import {SearchPage} from "./Pages/SearchPage";
import AddFile from "./Pages/AddFile"
import { Blanks } from './Components/Blanks';
function App() {
  return (

    // <BrowserRouter>
    // <Routes>
    //   <Route path='/' element={<LogIn/>} />
    //   <Route path='/register' element={<Register/>}/>
    //   <Route path='/AccountData' element={<FillAcount/>}/>
    //   <Route path="/Profile/:emailrouter" element={<Profile/>}/>
    //   <Route path="/search" element={<SearchPage/>}></Route>
    //   <Route path='/Home' element={<Home/>}/>
    //   <Route path="/Profile/:uid" element={<Profile/>}/>

    // </Routes>
    
    // </BrowserRouter>
    <Blanks curs='Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc aliquet mattis lacus eu commodo. Aliquam eu varius nisi. Nunc eu augue rutrum, auctor tortor in, pulvinar quam. Ut aliquam nec diam eu porta. Cras facilisis maximus elit maximus fermentum. Praesent eu leo orci. Pellentesque volutpat eros sed ipsum pulvinar dictum. Fusce sit amet felis eu ligula semper luctus. Donec sed vulputate eros. Nunc nec ligula nisl. Etiam orci odio, imperdiet sed lacinia nec, vestibulum et diam. Pellentesque a facilisis eros. Donec ac semper ligula. Duis ac lacinia metus. Fusce finibus non elit a congue.'></Blanks>
    
    
  );
}

export default App;
