import * as React from 'react';
import Button from '@mui/material/Button';
import Menu from '@mui/material/Menu';
import MenuItem from '@mui/material/MenuItem';
import { getUserData } from "./Authorize";
import Logout from './Logout';

const ProfileMenu = (...props) => {

    var userData = getUserData();
    const [anchorEl, setAnchorEl] = React.useState("")
    const open = Boolean(anchorEl);
    const handleClick = (event: React.MouseEvent<HTMLButtonElement>) => {
        setAnchorEl(event.currentTarget);
    };
    const handleClose = () => {
        setAnchorEl(null);
    };

    return (
        <div>
            <Button
                id="basic-button"
                aria-controls={open ? 'basic-menu' : undefined}
                aria-haspopup="true"
                aria-expanded={open ? 'true' : undefined}
                onClick={handleClick}>
                {userData.UserName}
            </Button>
            <Menu
                id="basic-menu"
                anchorEl={anchorEl}
                open={open}
                onClose={handleClose}
                MenuListProps={{
                    'aria-labelledby': 'basic-button',
                }}>
                <MenuItem onClick={handleClose}>Профиль</MenuItem>
                <MenuItem onClick={handleClose}>
                    <Logout></Logout>
                </MenuItem>
            </Menu>
        </div>
    );
}

export default ProfileMenu