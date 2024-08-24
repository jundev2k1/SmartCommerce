// Copyright (c) 2024 - Jun Dev. All rights reserved

import { useEffect, useRef } from 'react';
import { useTranslation } from 'react-i18next';

import { navBarList } from './navbar.logic';
import { default as MenuList } from './NavMenuList';
import { Container, LanguageSwitch, ThemeSwitch } from '../../index';
import './navbar.scss';

const NavBarComponent = () => {
  const navRef = useRef<HTMLElement>(null);
  const { t: translate } = useTranslation();
  const currentRoute = window.location.pathname;

  const handleScroll = () => {
    if (!navRef.current) return;
    const heightActive = 80;
    if (window.scrollY >= heightActive) {
      navRef.current.classList.add('nav--scroll');
    } else {
      navRef.current.classList.remove('nav--scroll');
    }
  };

  useEffect(() => {
    window.addEventListener('scroll', handleScroll);
    window.addEventListener('load', handleScroll);
    return () => {
      window.removeEventListener('scroll', handleScroll);
      window.removeEventListener('load', handleScroll);
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
                <li
                  className={`nav__menu__item${navbarItem.url === currentRoute ? ' nav__menu__item--active' : ''}`}
                  key={index}
                >
                  {navbarItem.items && navbarItem.items.length > 0 ? (
                    <MenuList
                      title={navbarItem.name}
                      subItems={navbarItem.items}
                    />
                  ) : (
                    <a className="nav__menu__link" href="#">
                      {translate(navbarItem.name).toUpperCase()}
                    </a>
                  )}
                </li>
              ))}
            </ul>
            <ul className="nav__menu__list">
              <li className="nav__menu__item">
                <ThemeSwitch />
              </li>
              <li className="nav__menu__item">
                <LanguageSwitch />
              </li>
            </ul>
          </div>
        </div>
      </Container>
    </header>
  );
};

export default NavBarComponent;
