import React from 'react';
import{ Navbar, Nav, NavLink  } from 'reactstrap';

export function Heading() {
    return(
        <Navbar>
        <Nav className="nav">
          <NavLink href="/">Vehicle Make</NavLink>
          <NavLink href="/vehicleModelList">Vehicle List</NavLink>
        </Nav>
      </Navbar>
    )
}
