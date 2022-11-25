import {Box, Typography} from "@mui/material";
import {useState} from "react";

interface Props {
    courseAbbreviation: string;
    onEnrollButtonPress?: () => void;
    isFavourite?: boolean;

}

export function CourseHeader(props: Props) {
    const {isFavourite, courseAbbreviation, onEnrollButtonPress} = props;
    const styles = {
        container: {
            height: 128,
            paddingTop: "56px",
            boxShadow: '0px 0px 10px #7C7C7C',
            borderBottomRightRadius: "20px",
            borderBottomLeftRadius: "20px",
        },
    };

    let [click, setClick] = useState(0);
    const [favourite, setFavourite] = useState(isFavourite);

    return (
        <Box sx={{
            justifyContent: "space-between",
            flexDirection: "row",
            alignItems: "center",
            display: "flex",
            backgroundColor: "violet",
        }}>
            <Typography color={"black"}>{courseAbbreviation}</Typography>
            <Box sx={{justifyContent: "space-between",
                flexDirection: "row",
                alignItems: "center",
                display: "flex",}}>
                <Typography color={"black"}>hey</Typography>
                <Typography color={"black"}>whatsup</Typography>
            </Box>
        </Box>
    )
}