import {Box, InputAdornment, TextField} from "@mui/material";
import React from "react";
import {BsSearch} from "react-icons/bs";

interface Props {
    searchedText: string;
    setSearchedText: React.Dispatch<React.SetStateAction<string>>;
}

export function SearchBar(props: Props) {
    const {setSearchedText, searchedText} = props;

    const styles = {
        container: {
            height: 128-56,
            paddingTop: "56px",
            boxShadow: '0px 0px 10px #7C7C7C',
            borderBottomRightRadius: "20px",
            borderBottomLeftRadius: "20px",
<<<<<<< Updated upstream
=======
            position: "fixed",
            backgroundColor: "white",
            top: 0,
            left: 0,
>>>>>>> Stashed changes
        },
    }

    return (
        <Box sx={styles.container}>
            <TextField
                id="input-with-icon-textfield"
                label={"Search..."}
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
        </Box>
    )
}