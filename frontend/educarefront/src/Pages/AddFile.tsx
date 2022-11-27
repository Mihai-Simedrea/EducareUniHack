import './App.css';
import React, {useState} from 'react';


function AddFile() {

  const [file, setFile] = useState()

  function handleChange(event:React.FormEvent<HTMLInputElement>) {
    setFile(event.target.files[0])
  }
  
  function handleSubmit(event:React.FormEvent<HTMLInputElement>) {
    event.preventDefault()
    const url = 'http://localhost:3000/uploadFile';
    const formData = new FormData();
    formData.append('file', file);
    formData.append('fileName', file.name);
    const config = {
      headers: {
        'content-type': 'multipart/form-data',
      },
    };
    

  }

  return (
    <div className="App">
        <form onSubmit={handleSubmit}>
          <h1>React File Upload</h1>
          <input type="file" onChange={handleChange}/>
          <button type="submit">Upload</button>
        </form>
    </div>
  );
}

export default AddFile;