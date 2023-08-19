import React, { Component } from 'react';
import { NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import '../../src/components/NavMenu.css';
import { getUserData, isAuthenticated } from "./Authorize";
import Logout from './Logout';

const NavLoginView = () => {
    if (isAuthenticated()) {
        var userData = getUserData();
        return (
            <NavItem>
                <span>{userData.UserName}</span>  <Logout />
            </NavItem>
        )
    } else {
        return (
            <NavItem>
                <NavLink tag={Link} className="text-dark" to="/login">Login</NavLink>
                <NavLink tag={Link} className="text-dark" to="/register">Register</NavLink>
            </NavItem>
        )
    }
}

export default NavLoginView