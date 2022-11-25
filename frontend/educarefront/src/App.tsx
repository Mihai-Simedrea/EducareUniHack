import React, {useState} from 'react';
import logo from './logo.svg';
import './App.css';
import UniversityOrFieldCard from "./Components/UniversityOrFieldCard";
import {CourseCard} from "./Components/CourseCard";
import {Box, Typography} from "@mui/material";
import {SearchBar} from "./Components/SearchBar";

function App() {
    const [searchedText, setSearchedText] = useState("");

    return (
        <div className="App">
            <header className="App-header">
                <SearchBar searchedText={searchedText} setSearchedText={setSearchedText}/>
            </header>
        </div>
    );
}

export default App;
