import { Card, Box, CardMedia,TextField,Typography,Button,Alert } from "@mui/material";
import { height } from "@mui/system";
import {useNavigate} from "react-router-dom"
import {useState,useEffect} from "react";
import { UserRegisterDto, UsersClient } from "../api";


const Register=()=>{
    const navigate=useNavigate();
    const [username,setUsername]=useState(" ");
    const [password,setPassword]=useState(" ");
    const [passwordMatch,setPasswordMatch]=useState(" ");
    const [email,setEmail]=useState(" ");
    const [errorView,setErrorView]=useState("none");
    const userbackend=new UsersClient();
    const handleSubmit= async()=>{
        await userbackend.register({email:email,userName:username,password:password} as UserRegisterDto)
    }
    useEffect(()=>{
        
        if(passwordMatch!=password){
            setErrorView(" ");

        }
        else{
            setErrorView("none");
        }


    },[passwordMatch])
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
    sx={{ width: "20rem",
          display: "flex",
          flexDirection: "column",
          justifyContent: "flex-start",
          alignItems: "center",
          height:'38rem',
          boxShadow:'10',
          gap:'10px',
          backgroundColor:'white',
          borderRadius:'10px'
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
          height:"21rem",
          boxShadow:'0',
        }}
      >
        <Box
        sx={{width:'100%',display:'flex',flexDirection:'column',justifyContent:'center',alignItems:'Center',height:'100%',gap:'30px'}}
        >
            <TextField id="outlined-basic" label='Username' sx={{width:'80%'}}  onChange={(e)=>{
                setUsername(e.target.value);
            }} required color='success'></TextField>
            <TextField id="outlined-basic" label='E-mail' sx={{width:'80%'}} onChange={(e)=>{
                setEmail(e.target.value);
            }} required color='success'></TextField>
             <TextField id="outlined-basic" label='Password' sx={{width:'80%'}}  type="password" onChange={(e)=>{
                setPassword(e.target.value);
            }} required color='success'></TextField>
            <TextField id="outlined-basic" label='RepeatPassword' sx={{width:'80%'}} type="password" onChange={(e)=>{
                setPasswordMatch(e.target.value);
            }} required color='success'></TextField>

        </Box>
      </Card>
      <Box sx={{width:'100%',display:'flex',flexDirection:'column',justifyContent:'center',alignItems:'Center',height:'4rem',gap:'10px'}}>
        <Button variant="contained" color="success" sx={{width:'30%'}} type="submit">Submit</Button>
      </Box>
      <Alert sx={{width:'70%',height:'2rem',display:errorView}} severity="error">Password Does Not Match</Alert>
      </Box>
    </Box>
  );

}

export default Register