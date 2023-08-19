import React, { useState } from "react";
import axios from "axios";
import { Navigate } from "react-router-dom";
import { isAuthenticated } from "./Authorize";

const Login = () => {
    const [login, setLogin] = useState("");
    const [password, setPassword] = useState("");
    const [errorMessage, setErrorMessage] = useState("");

    const handleLogin = async () => {
        try {
            const response = await axios.post("/api/auth/login", {
                login,
                password,
            });

            const token = response.data.token;
            // Сохраните токен в localStorage или cookies
            localStorage.token = token;

            window.location.reload(); 
        } catch (error) {
            console.error("Ошибка входа", error);
            setErrorMessage("Неверное имя пользователя и (или) пароль");
        }
    };

    return isAuthenticated() ? (<Navigate to="/"></Navigate>) : (
        <div className="container">
            <h2>Вход</h2>
            {errorMessage && <p style={{ color: "red" }}>{errorMessage}</p>}
            <form>
                <div className="form-group">
                    <label>Email:</label>
                    <input
                        type="email"
                        className="form-control"
                        placeholder="Введите email"
                        onChange={(e) => setLogin(e.target.value)}
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
