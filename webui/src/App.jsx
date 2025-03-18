import { useState, useEffect } from 'react'
import './App.css'

function App() {
    const [data, setData] = useState([]);
    const [firstname, setFirstname] = useState("");
    const [lastname, setLastname] = useState("");

    const handleChangeFirstname = (e) => {
        setFirstname(e.target.value);
    }

    const handleChangeLastname = (e) => {
        setLastname(e.target.value);
    }

    const getContacts = () => {
        fetch("https://localhost:22950/c")
            .then(res => res.json())
            .then(data => {
                setData(data);
            })
    }


    const onSave = () => {
        const body = {
            firstname: firstname ?? "no name",
            lastname: lastname ?? "no surname"
        };
        fetch("https://localhost:22950/c", {
            method: "POST",
            body: JSON.stringify(body),
            headers: {
                "content-type": "application/json"
            }
        })
            .then(res => res.json())
            .then(data => {
                console.log(data);
                setFirstname("");
                setLastname("");
                getContacts();
            })
    }

    useEffect(() => {
        getContacts();
    }, []);

    return (
        <>
            <h1>Add New Contact</h1>
            <div>
                <label>Firstname</label>
                <input onChange={handleChangeFirstname} value={firstname} />
            </div>
            <div>
                <label>Lastname</label>
                <input onChange={handleChangeLastname} value={lastname} />
            </div>
            <button onClick={onSave}>Save</button>
            {
                data && data.map((d) => (
                    <div key={d.id}>
                        <h1>Firstname {d.firstname}</h1>
                        <h1>Lastname {d.lastname}</h1>
                    </div>
                ))
            }
        </>
    )
}

export default App
