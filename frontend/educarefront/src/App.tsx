import React, {useState} from 'react';
import logo from './logo.svg';
import  {BrowserRouter,Routes,Route} from "react-router-dom"
import LogIn from './Pages/LogIn';
import Register from './Pages/Register';
import FillAcount from './Pages/FillAcount';
import Profile from './Components/Profile';
import {SearchBar} from "./Components/SearchBar";
import {SearchPage} from "./Pages/SearchPage";
function App() {
  const [inputText,setInputText] = useState("");
  return (

    <BrowserRouter>
    <Routes>
      <Route path='/' element={<LogIn/>} />
      <Route path='/register' element={<Register/>}/>
      <Route path='/AccountData' element={<FillAcount/>}/>
      <Route path="/Profile/:emailrouter" element={<Profile/>}/>
      <Route path = "/Search" element={<SearchPage/>}/>

    </Routes>

    </BrowserRouter>

    // <SearchPage></SearchPage>
  );
}

export default App;
