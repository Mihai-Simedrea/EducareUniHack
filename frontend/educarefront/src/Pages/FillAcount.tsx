import {
  Card,
  Box,
  CardMedia,
  TextField,
  Typography,
  Button,
  Alert,
  Select,
  MenuItem,
  FormControl,
} from "@mui/material";
import InputLabel from "@mui/material/InputLabel";
import { height } from "@mui/system";
import {useNavigate, Navigate, Link} from "react-router-dom";
import { useState, useEffect } from "react";
import useLocal from "../CustomHooks/useLocal";
import HandleUserData from "../endpoints/HandleUserData";

type usesrBody={
    numberOfLikes:string,
    numberOfPosts:string;
}
const FillAcount =() => {
 const navigate=useNavigate();
 const userback=HandleUserData();
 const local=useLocal();
 const uid=local.getLocalEntry("uid");
 const handleSubmit=async()=>{
    const res=await userback.UpdateProfileData(university,field,degree,year,uid);
    local.createLocalEntry("university",university);
    local.createLocalEntry("field",field);
    local.createLocalEntry("year",year);
    const profileres=await userback.GetProfile(uid);
    const profiledata= await profileres.json() as usesrBody;
    console.log(profiledata);
    local.createLocalEntry("posts",profiledata.numberOfPosts);
    local.createLocalEntry("likes",profiledata.numberOfLikes);
}
const [status,setStatus]=useState(0);
const checkFill=async()=>{
    const res=await userback.GetProfile(uid);
    if(res.status!=204){
        navigate('/Home');
    }
    
}
useEffect(()=>{
    checkFill();

},[])


  const University = [
    "Universitatea Politehnica Timisoara",
    "Harvard",
    "Universitatea Politehnica Bucuresti",
    "Universitatea Politehnica Cluj",
  ];
  const Field = ["AC", "ETC", "Mecanica", "Constructii"];
  const Degree = ["CTI", "IS", "ETTI", "Mecatronica", "IngCivil"];
  const Year = ["1", "2", "3", "4", "not in university"];
  const [university, setUniversity] = useState("");
  const [field, setField] = useState("");
  const [degree, setDegree] = useState("");
  const [year, setYear] = useState("");
  return (
    <Box
      sx={{
        width: "100%",
        height: "100vh",
        justifyContent: "center",
        alignItems: "center",
        display: "flex",
      }}
    >
      <Box
        sx={{
          width: "352px",
          display: "flex",
          flexDirection: "column",
          justifyContent: "flex-start",
          alignItems: "center",
          height: "44rem",
          boxShadow: "10",
          gap: "10px",
          backgroundColor: "white",
          borderRadius: "30px",
        }}
        component="form"
        onSubmit={(e) => {
          e.preventDefault();
          handleSubmit();
        }}
      >
        <Box
          sx={{
            clipPath: "circle(44.6% at 50% 0)",
            width: "4rem",
            backgroundColor: "rgb(46,125,50)",
            height: "4rem",
          }}
        ></Box>
        <Typography variant="h5">Fill Account Data</Typography>
        <Card
          sx={{
            width: "100%",
            display: "flex",
            flexDirection: "column",
            justifyContent: "center",
            alignItems: "center",
            height: "30rem",
            boxShadow: "0",
          }}
        >
          <Box
            sx={{
              width: "100%",
              display: "flex",
              flexDirection: "column",
              justifyContent: "center",
              alignItems: "Center",
              height: "100%",
              gap: "30px",
            }}
          >
            <Box
              sx={{
                width: "70%",
                display: "flex",
                flexDirection: "column",
                height: "6rem",
                gap: "4px",
                justifyContent: "center",
                alignItems: "center",
              }}
            >
              <Typography variant="subtitle1" sx={{ alignSelf: "flex-start" }}>
                Choose University:
              </Typography>

              <Select
                color="success"
                //   labelId="demo-simple-select-label"
                labelId="demo-simple-select-autowidth-label"
                id="demo-simple-select-autowidth"
                sx={{ width: "100%" }}
                required
                value={university}
                onChange={(e) => {
                  setUniversity(e.target.value);
                }}
              >
                {University.map((e) => {
                  return (
                    <MenuItem value={e} key={e}>
                      {e}
                    </MenuItem>
                  );
                })}
              </Select>
            </Box>
            <Box
              sx={{
                width: "70%",
                display: "flex",
                flexDirection: "column",
                height: "6rem",
                gap: "4px",
                justifyContent: "center",
                alignItems: "center",
              }}
            >
              <Typography variant="subtitle1" sx={{ alignSelf: "flex-start" }}>
                Choose Field:
              </Typography>
              <Select
                color="success"
                required
                labelId="demo-simple-select-label"
                sx={{ width: "100%" }}
                value={field}
                onChange={(e) => {
                  setField(e.target.value);
                }}
              >
                {Field.map((e) => {
                  return (
                    <MenuItem value={e} key={e}>
                      {e}
                    </MenuItem>
                  );
                })}
              </Select>
            </Box>
            <Box
              sx={{
                width: "70%",
                display: "flex",
                flexDirection: "column",
                height: "6rem",
                gap: "4px",
                justifyContent: "center",
                alignItems: "center",
              }}
            >
              <Typography variant="subtitle1" sx={{ alignSelf: "flex-start" }}>
                Choose Degree:
              </Typography>
              <Select
                color="success"
                required
                labelId="demo-simple-select-label"
                sx={{ width: "100%" }}
                value={degree}
                onChange={(e) => {
                  setDegree(e.target.value);
                }}
              >
                {Degree.map((e) => {
                  return (
                    <MenuItem value={e} key={e}>
                      {e}
                    </MenuItem>
                  );
                })}
              </Select>
            </Box>
            <Box
              sx={{
                width: "70%",
                display: "flex",
                flexDirection: "column",
                height: "6rem",
                gap: "4px",
                justifyContent: "center",
                alignItems: "center",
              }}
            >
              <Typography variant="subtitle1" sx={{ alignSelf: "flex-start" }}>
                Choose Year:
              </Typography>
              <Select
                color="success"
                required
                labelId="demo-simple-select-label"
                sx={{ width: "100%" }}
                value={year}
                onChange={(e) => {
                  setYear(e.target.value);
                }}
              >
                {Year.map((e) => {
                  return (
                    <MenuItem value={e} key={e}>
                      {e}
                    </MenuItem>
                  );
                })}
              </Select>
            </Box>
          </Box>
        </Card>
        <Box
          sx={{
            width: "100%",
            display: "flex",
            flexDirection: "column",
            justifyContent: "center",
            alignItems: "Center",
            height: "4rem",
            gap: "10px",
          }}
        >
          <Button
              component = {Link}
            variant="contained"
            color="success"
            sx={{ width: "30%" }}
            type="submit"
            to="/search"
          >
              Submit
          </Button>
        </Box>
      </Box>
    </Box>
  );
};

export default FillAcount;
