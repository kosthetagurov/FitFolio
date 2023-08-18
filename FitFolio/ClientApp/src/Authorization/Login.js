import React, { useState } from "react";
import axios from "axios";

const Login = () => {
    const [username, setUserName] = useState("");
    const [password, setPassword] = useState("");

    const handleLogin = async () => {
        try {
            const response = await axios.post("/api/auth/login", {
                username,
                password,
            });

            const token = response.data.token;
            // Сохраните токен в localStorage или cookies

            // Перенаправьте пользователя на другую страницу
        } catch (error) {
            console.error("Ошибка входа", error);
        }
    };

    return (
        <div className="container">
            <h2>Вход</h2>
            <form>
                <div className="form-group">
                    <label>Email:</label>
                    <input
                        type="email"
                        className="form-control"
                        placeholder="Введите email"
                        onChange={(e) => setUserName(e.target.value)}
                    />
                </div>
                <div className="form-group">
                    <label>Пароль:</label>
                    <input
                        type="password"
                        className="form-control"
                        placeholder="Введите пароль"
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </div>
                <button type="button" className="btn btn-primary" onClick={handleLogin}>Войти</button>
            </form>
        </div>
    );
};

export default Login;
