import React from 'react';
import { Link } from 'react-router-dom';
import{ Navbar, Nav, NavItem, NavbarBrand, Container } from 'reactstrap';

export const Heading = () => {
    return(
       <Navbar color="dark" dark>
           <Container>
               <NavbarBrand href="/">Vehicle</NavbarBrand>
               <Nav>
                   <NavItem>
                       <Link className="btn btn-primary"  to="/VehicleMakeCreate">Add Vehicle</Link>
                   </NavItem>
               </Nav>
           </Container>
       </Navbar>
    )
}