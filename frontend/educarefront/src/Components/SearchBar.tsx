import {Box, InputAdornment, Select, TextField} from "@mui/material";
import React from "react";
import {BsSearch} from "react-icons/bs";

interface Props {
    searchedText: string;
    setSearchedText: React.Dispatch<React.SetStateAction<string>>;
    searchBy: "University" | "Field" | "Courses";
    fields?: object;
    years?: object;
}

export function SearchBar(props: Props) {
    const {setSearchedText, searchedText, searchBy, fields, years} = props;

    const styles = {
        container: {
            height: 72,
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            width: "100vw",
            paddingTop: "56px",
            boxShadow: '0px 0px 10px #7C7C7C',
            borderBottomRightRadius: "20px",
            borderBottomLeftRadius: "20px",
            position: "fixed",
            backgroundColor: "white",
            top: 0,
            left:0
        },
    };

    return (
        <Box sx={styles.container}>
            <TextField
                id="input-with-icon-textfield"
                label={searchBy}
                InputProps={{
                    endAdornment: (
                        <InputAdornment position={"end"}>
                            <BsSearch/>
                        </InputAdornment>
                    )
                }}
                onChange={(e) => {
                    setSearchedText(e.target.value)
                }}
            />
            {searchBy === 'Courses' &&
                <Box sx={{display: "flex", justifyContent: "center", alignItems: "center"}}>
                </Box>
            }
        </Box>
    )
}