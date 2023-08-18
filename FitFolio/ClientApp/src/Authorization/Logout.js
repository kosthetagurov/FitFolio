import React from "react";
import axios from "axios";

const Logout = () => {
    const handleLogout = async () => {
        try {
            await axios.post("/api/auth/logout");
            // Очистите токен из localStorage или cookies
            // Перенаправьте пользователя на страницу входа или выполните другие действия

        } catch (error) {
            console.error("Ошибка выхода", error);
        }
    };

    return (
        <div className="container">
            <h2>Выход</h2>
            <button type="button" className="btn btn-danger" onClick={handleLogout}>Выход</button>
        </div>
    );
};

export default Logout;
