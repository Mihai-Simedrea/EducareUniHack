import { Box, Avatar, Typography, Button } from "@mui/material";
import { useState, useEffect } from "react";
import useLocal from "../CustomHooks/useLocal";
import { useNavigate, useParams } from "react-router-dom";
import HandleUserData from "../endpoints/HandleUserData";
import LabelBottomNavigation from "./LabelBottomNavigation";
type ProfileResponse={
    universityName:string;
    fieldName:string;
    facultyName:string;
    numberOfLikes:string;
    numberOfPosts:string;
    users:{userName:string;}

}
const Profile = () => {
  const { uid } = useParams();
  const userback=HandleUserData();
  const navigate = useNavigate();
  const [university, setUniversity] = useState<string | null>(" ");
  const [field, setField] = useState<string | null>(" ");
  const [degree, setDegree] = useState<string | null>(" ");
  const [buttonView, setButtonView] = useState<string | null>(" ");
  const [contentLike, setContentLike] = useState<string | null>(" ");
  const [posts, setPosts] = useState<string | null>(" ");
  const [userName,setUsername]=useState(' ');
  const local = useLocal();
  const handleOtherView=async ()=>{
    const res=await userback.GetProfile(uid as string);
    const data=await res.json() as ProfileResponse;
    setUniversity(data.universityName);
    setDegree(data.facultyName);
    setField(data.fieldName);
    setPosts(data.numberOfPosts);
    setContentLike(data.numberOfLikes);
    setUsername(data.users.userName);
  }

  useEffect(() => {
    console.log(uid);
    if (local.getLocalEntry("uid") != null) {
      if (uid == local.getLocalEntry("uid")) {
        setUniversity(local.getLocalEntry("university"));
        setDegree(local.getLocalEntry("degree"));
        setField(local.getLocalEntry("field"));
        setPosts(local.getLocalEntry("posts"));
        setContentLike(local.getLocalEntry("likes"));
      }
      else{
        setButtonView('none');
        handleOtherView();
      }
    }
  }, []);

  return (
    <Box
      sx={{
        width: "100%",
        height: "100%",
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        justifyContent: "center",
          alignSelf:'center'
      }}
    >
      <Box
        sx={{
          width: "400px",
          height: "500px",
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
          justifyContent: "center",
            borderRadius:'30px'
        }}
      >
        <Avatar
          sx={{ width: "10rem", height: "10rem" }}
          src={require("../Assets/images/profile.jpg")}
        ></Avatar>
        <Typography variant='h6'>{userName}</Typography>
        <Box
          sx={{
            width: "70%",
            height: "10rem",
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            justifyContent: "center",
          }}
        >
          <Typography variant="subtitle1">Universitatea Politehinica Timisoara</Typography>
          <Typography variant="subtitle1">Automatica si Calculatoare</Typography>
          <Typography variant="subtitle1">CTI</Typography>
          <Typography>Likes Recevide: 0</Typography>
          <Typography>Posts Uploaded: 0</Typography>
        </Box>
        <Box
          sx={{
            width: "70%",
            height: "fit-content",
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            justifyContent: "center",
            gap: "4px",
          }}
        >
          <Button
            variant="contained"
            sx={{ width: "9rem"}}
            onClick={() => {
              navigate("/AccountData");
            }}
            color="success"
          >
            Edit Profile
          </Button>
          <Button
            variant="contained"
            sx={{ width: "9rem"}}
            color="success"
          >
            Log Out
          </Button>
        </Box>
      </Box>
        <LabelBottomNavigation icon={4}></LabelBottomNavigation>
    </Box>
  );
};
export default Profile;
