import React from "react";
import axios from "axios";
import '../../src/components/NavMenu.css';

const Logout = () => {
    const handleLogout = async () => {
        try {
            var response = await axios.post("/api/auth/logout");
            if (response.status == 200) {
                localStorage.clear();                
            }

            window.location.reload();          
        } catch (error) {
            console.error("Ошибка выхода", error);
        }
    };

    return (
        <a role="button" className="text-dark" onClick={handleLogout}>Выход</a>
    );
};

export default Logout;
