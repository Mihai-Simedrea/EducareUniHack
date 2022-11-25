import React from 'react';
import logo from './logo.svg';
import  {BrowserRouter,Routes,Route} from "react-router-dom"
import LogIn from './Pages/LogIn';
import Register from './Pages/Register';
import FillAcount from './Pages/FillAcount';
import Profile from './Components/Profile';
function App() {
  return (
    <BrowserRouter>
    <Routes>
      <Route path='/' element={<LogIn/>} />
      <Route path='/register' element={<Register/>}/>
      <Route path='/AccountData' element={<FillAcount/>}/>
      <Route path="/Profile" element={<Profile/>}/>
      
    </Routes>
    
    </BrowserRouter>
   
  );
}

export default App;
