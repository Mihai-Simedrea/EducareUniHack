import React, {useState} from 'react';
import logo from './logo.svg';
import './App.css';
import UniversityOrFieldCard from "./Components/UniversityOrFieldCard";
import {CourseCard} from "./Components/CourseCard";
import {Box, Typography} from "@mui/material";
import {SearchBar} from "./Components/SearchBar";
import {CourseHeader} from "./Components/CourseHeader";

function App() {
    const [searchedText, setSearchedText] = useState("");

    return (
        <div className="App">
            <header className="App-header">
                <CourseHeader courseAbbreviation={"AC"}/>
            </header>
        </div>
    );
}

export default App;
