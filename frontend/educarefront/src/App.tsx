import React from 'react';
import logo from './logo.svg';
import './App.css';
import UniversityOrFieldCard from "./Components/UniversityOrFieldCard";
import {CourseCard} from "./Components/CourseCard";
import {Box} from "@mui/material";

function App() {
    return (
        <div className="App">
            <header className="App-header">
                <UniversityOrFieldCard
                    universityOrFieldName={"Automatica si Calculatoare"}
                    nrOfExercises={56}
                    nrOfMaterialsUploaded={123}
                    nrOfFields={12}
                    isUniversity={true}
                />
                <Box sx={{marginBottom: "16px", marginTop: "16px"}}></Box>
                <CourseCard
                    courseAbbreviation={'PTDM'}
                    onHeartPress={() => {
                        console.log("hey")
                    }}
                    isFavourite={false}
                    degreeAbbreviation={"CTI"}
                    fieldName={"Automatica si Calculatoare"}
                    universityName={"Universitatea Politehnica Timisoara"}
                    year={2}

                />
            </header>
        </div>
    );
}

export default App;
