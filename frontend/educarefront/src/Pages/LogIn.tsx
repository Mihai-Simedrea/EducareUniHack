import { Card, Box, CardMedia,TextField,Typography,Button,Alert} from "@mui/material";
import { height } from "@mui/system";
import {useNavigate} from "react-router-dom"
import {useState} from "react";
import { UserLoginDto, UsersClient } from "../api";
import HandleUserData from "../endpoints/HandleUserData";
import HandleUniversity from "../endpoints/HandleUniversity";
import useLocal from "../CustomHooks/useLocal";
const LogIn = () => {
    const navigate=useNavigate();
    const userend=HandleUserData();
    const local=useLocal();
    const [email,setEmail]=useState(" ");
    const [password,setPassword]=useState(" ");
    const [error,setError]=useState("none");
    const handleSubmit= async ()=>{
        try {
       const res=await userend.Login(email,password);
        const resvalue=await res.json();
  
        if(resvalue!=null){
            local.createLocalEntry('uid',resvalue);
            navigate("/AccountData");
        }
        else{
            setError(' ');
        }
        } catch (error) {
            console.log(error);  }
       
    }
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

        <Card
        sx={{width:'100%',height:'100vh',position:'absolute',zIndex:'-1'}}
        >
            <CardMedia
              sx={{width:'100%',height:'100vh',position:'absolute',zIndex:'-1'}}
              component="img"
              height="100vh"
              image={require('../Assets/images/login.jpg')}

            
            ></CardMedia>
        </Card>
    <Box
    sx={{ width: "352px",
          display: "flex",
          flexDirection: "column",
          justifyContent: "flex-start",
          alignItems: "center",
          height:'33rem',
          boxShadow:'10',
          gap:'10px',
          backgroundColor:'white',
          borderRadius:'30px'
          }}
          component='form'
          onSubmit={(e)=>{
            e.preventDefault();
            handleSubmit();
          }}
          >  

     <Box sx={{clipPath:"circle(44.6% at 50% 0)",width:'4rem',backgroundColor:"rgb(46,125,50)",height:'4rem'}}></Box>
     <Typography variant="h5" >Welcome to Educare</Typography>
      <Card
        sx={{
          width: "100%",
          display: "flex",
          flexDirection: "column",
          justifyContent: "center",
          alignItems: "center",
          height:"15rem",
          boxShadow:'0',
        }}
      >
        <Box
        sx={{width:'100%',display:'flex',flexDirection:'column',justifyContent:'center',alignItems:'Center',height:'100%',gap:'30px'}}
        >
            <TextField id="outlined-basic" label='E-mail' sx={{width:'80%'}}  onChange={(e)=>{
                setEmail(e.target.value);
            }} required color='success'></TextField>
            <TextField id="outlined-basic" label='Password' sx={{width:'80%'}} type="password" onChange={(e)=>{
                setPassword(e.target.value);
            }} required color='success'></TextField>

        </Box>
      </Card>
      <Box sx={{width:'100%',display:'flex',flexDirection:'column',justifyContent:'center',alignItems:'Center',height:'4rem',gap:'10px'}}>
        <Button variant="contained" color="success" sx={{width:'30%'}} type="submit">Submit</Button>
        <Button variant="contained" color="success" sx={{width:'30%'}} onClick={()=>{
           navigate('/register');
        }} >Register</Button>
      </Box>
      <Alert sx={{width:'70%',height:'2rem',display:error,alignContent:'center',justifyContent:'center',marginTop:'10px'}} severity="error">Incorrect Username or Password</Alert>
      </Box>
    </Box>
  );
};

export default LogIn;
