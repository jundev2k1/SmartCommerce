// Copyright (c) 2024 - Jun Dev. All rights reserved

import { useTranslation } from 'react-i18next';
import { Container } from '../../../components';
import { navBarList } from './navbar.logic';
import './navbar.scss';
import { useEffect, useRef } from 'react';

const NavBar = () => {
  const navRef = useRef<HTMLElement>(null);
  const { t: translate } = useTranslation();
  const isActive = true;

  const handleScroll = () => {
    if (!navRef.current) return;
    const heightActive = window.innerHeight - 80;
    if (window.scrollY >= heightActive) {
      navRef.current.classList.add('nav--scroll');
    } else {
      navRef.current.classList.remove('nav--scroll');
    }
  };

  useEffect(() => {
    window.addEventListener('scroll', handleScroll);
    return () => {
      window.removeEventListener('scroll' ,handleScroll);
    };
  }, []);
  return (
    <header className="nav" ref={navRef}>
      <Container maxWidth="lg">
        <div className="nav__wrapper">
          <div className="nav__logo">
            <img src="/logo512.png" />
          </div>
          <div className="nav__menu">
            <ul className="nav__menu__list">
              {navBarList.map((navbarItem, index) => (
                <li className="nav__menu__item" key={index}>
                  <a className="nav__menu__link" href="#">
                    {translate(navbarItem.name).toUpperCase()}
                  </a>
                  {navbarItem.items && (
                    <ul>
                      {navbarItem.items.map((childItem, childIndex) => (
                        <li key={childIndex}>{childItem.name}</li>
                      ))}
                    </ul>
                  )}
                </li>
              ))}
            </ul>
          </div>
        </div>
      </Container>
    </header>
  );
};

export default NavBar;
