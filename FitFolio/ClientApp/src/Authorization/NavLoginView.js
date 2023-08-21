import React from 'react';
import { NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import '../../src/components/NavMenu.css';
import { getUserData, isAuthenticated } from "./Authorize";
import Logout from './Logout';
import ProfileMenu from './ProfileMenu.js'

const NavLoginView = () => {
    if (isAuthenticated()) {
        var userData = getUserData();
        return (
            <ul className="navbar-nav flex-grow">
                <ProfileMenu />
            </ul>
        )
    } else {
        return (
            <ul className="navbar-nav flex-grow">
                <NavItem>
                    <NavLink tag={Link} className="text-dark" to="/login">Login</NavLink>
                </NavItem>
                <NavItem>
                    <NavLink tag={Link} className="text-dark" to="/register">Register</NavLink>
                </NavItem>
            </ul>
        )
    }
}

export default NavLoginView