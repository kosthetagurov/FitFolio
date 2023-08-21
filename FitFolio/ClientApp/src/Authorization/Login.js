import React, { useState } from "react";
import axios from "axios";
import { Link, Navigate } from "react-router-dom";
import { isAuthenticated } from "./Authorize";

const Login = () => {
    const [login, setLogin] = useState("");
    const [password, setPassword] = useState("");
    const [errorMessage, setErrorMessage] = useState("");

    const formStyles = {
        width: "60%",
        margin: "0 auto"
    }

    const handleLogin = async () => {
        try {
            const response = await axios.post("/api/auth/login", {
                Login: login,
                Password: password,
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
            <h2 className="text-center">Вход</h2>
            {errorMessage && <p style={{ color: "red" }}>{errorMessage}</p>}
            <form style={formStyles}>
                <div className="form-outline mb-4">
                    <label className="form-label" htmlFor="email">Email</label>
                    <input
                        type="email"
                        className="form-control"
                        placeholder="Введите email"
                        onChange={(e) => setLogin(e.target.value)}
                        id="email"
                    />                    
                </div>

                <div className="form-outline mb-4">
                    <label className="form-label" htmlFor="passowrd">Пароль</label>
                    <input
                        type="password"
                        className="form-control"
                        placeholder="Введите пароль"
                        onChange={(e) => setPassword(e.target.value)}
                        id="passowrd"
                    />                    
                </div>               

                <div className="text-center">
                    <button type="button" className="btn btn-primary btn-block mb-4" onClick={handleLogin}>Войти</button>
                    <p>Нет аккаунта? <Link to="/register">Зарегистрироваться</Link></p>
                </div>
            </form>
        </div>
    );
};

export default Login;
