import React from "react";
import { Navigate } from "react-router-dom";
import jwtDecode from "jwt-decode";

const Authorize = (WrappedComponent) => {
    return class extends React.Component {
        constructor(props) {
            super(props);            
        }

        render() {
            if (isAuthenticated()) {
                return <WrappedComponent {...this.props} />;
            } else {
                return <Navigate to="/login" />; // Перенаправление на страницу входа
            }
        }
    };
};

const decodeToken = () => {
    // Проверка наличия JWT-токена в localStorage
    const token = localStorage.getItem("token");
    if (token) {
        const decodedToken = jwtDecode(token);
        return decodedToken;
    }
}

const getUserData = () => {
    if (isAuthenticated()) {
        var decodedToken = decodeToken();
        return JSON.parse(decodedToken.UserPublicData)
    } else {
        return {
            UserName: "anonymous"
        }
    }    
}

const isAuthenticated = () => {
    var decodedToken = decodeToken();
    if (decodedToken) {
        return true;
    } else {
        return false;
    }    
}

export { Authorize, decodeToken, getUserData, isAuthenticated };