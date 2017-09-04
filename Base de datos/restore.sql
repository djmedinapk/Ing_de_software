--
-- NOTE:
--
-- File paths need to be edited. Search for $$PATH$$ and
-- replace it with the path to the directory containing
-- the extracted data files.
--
--
-- PostgreSQL database dump
--

-- Dumped from database version 9.6.4
-- Dumped by pg_dump version 9.6.4

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

SET search_path = public, pg_catalog;

ALTER TABLE ONLY public.carrito DROP CONSTRAINT id_usuario;
ALTER TABLE ONLY public.carrito DROP CONSTRAINT id_producto;
ALTER TABLE ONLY public.usuario DROP CONSTRAINT usuario_pkey;
ALTER TABLE ONLY public.productos DROP CONSTRAINT productos_pkey;
ALTER TABLE ONLY public.carrito DROP CONSTRAINT carrito_pkey;
ALTER TABLE public.usuario ALTER COLUMN id DROP DEFAULT;
ALTER TABLE public.productos ALTER COLUMN id DROP DEFAULT;
ALTER TABLE public.carrito ALTER COLUMN id DROP DEFAULT;
DROP VIEW public.v_carrito;
DROP SEQUENCE public.usuario_id_seq;
DROP SEQUENCE public.productos_id_seq;
DROP SEQUENCE public.carrito_id_seq;
DROP TABLE public.carrito;
DROP FUNCTION public.f_obtener_productos();
DROP TABLE public.productos;
DROP FUNCTION public.f_obtener_carrito(_iduser integer);
DROP VIEW public.v_carrito1;
DROP FUNCTION public.f_consultar_login(_username character varying, _pass character varying);
DROP TABLE public.usuario;
DROP EXTENSION plpgsql;
DROP SCHEMA public;
--
-- Name: public; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA public;


ALTER SCHEMA public OWNER TO postgres;

--
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: postgres
--

COMMENT ON SCHEMA public IS 'standard public schema';


--
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- Name: usuario; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE usuario (
    id integer NOT NULL,
    nombre character varying(100) NOT NULL,
    apellido character varying(100),
    username character varying(50) NOT NULL,
    pass character varying(50) NOT NULL,
    rol integer DEFAULT 1 NOT NULL
);


ALTER TABLE usuario OWNER TO postgres;

--
-- Name: f_consultar_login(character varying, character varying); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION f_consultar_login(_username character varying, _pass character varying) RETURNS SETOF usuario
    LANGUAGE plpgsql
    AS $$

	BEGIN
    	RETURN QUERY
    	SELECT * from public.usuario where pass = _pass AND username = _username limit 1;
  END

$$;


ALTER FUNCTION public.f_consultar_login(_username character varying, _pass character varying) OWNER TO postgres;

--
-- Name: v_carrito1; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW v_carrito1 AS
 SELECT ''::character varying(100) AS nombre_producto,
    0 AS cantidad,
    (0)::money AS precio,
    0 AS total;


ALTER TABLE v_carrito1 OWNER TO postgres;

--
-- Name: f_obtener_carrito(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION f_obtener_carrito(_iduser integer) RETURNS SETOF v_carrito1
    LANGUAGE plpgsql
    AS $$

	BEGIN
    	RETURN QUERY
    	SELECT p.nombre,c.cantidad,p.precio,(c.cantidad*p.precioo) from carrito c,productos p,usuario a where c.id_usuario= a.id and c.id_producto=p.id and a.id=_iduser and c.estado='no-pago';
  END

$$;


ALTER FUNCTION public.f_obtener_carrito(_iduser integer) OWNER TO postgres;

--
-- Name: productos; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE productos (
    id integer NOT NULL,
    nombre character varying(100) NOT NULL,
    descripcion character varying(200) NOT NULL,
    precio money NOT NULL,
    imagen text DEFAULT '../img/img.png'::text,
    precioo integer
);


ALTER TABLE productos OWNER TO postgres;

--
-- Name: f_obtener_productos(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION f_obtener_productos() RETURNS SETOF productos
    LANGUAGE plpgsql
    AS $$

	BEGIN	
   RETURN QUERY
   SELECT * FROM public.productos;
	END;

$$;


ALTER FUNCTION public.f_obtener_productos() OWNER TO postgres;

--
-- Name: carrito; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE carrito (
    id integer NOT NULL,
    id_producto integer NOT NULL,
    id_usuario integer NOT NULL,
    cantidad integer NOT NULL,
    estado character varying(10) DEFAULT 'no-pago'::character varying NOT NULL
);


ALTER TABLE carrito OWNER TO postgres;

--
-- Name: carrito_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE carrito_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE carrito_id_seq OWNER TO postgres;

--
-- Name: carrito_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE carrito_id_seq OWNED BY carrito.id;


--
-- Name: productos_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE productos_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE productos_id_seq OWNER TO postgres;

--
-- Name: productos_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE productos_id_seq OWNED BY productos.id;


--
-- Name: usuario_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE usuario_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE usuario_id_seq OWNER TO postgres;

--
-- Name: usuario_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE usuario_id_seq OWNED BY usuario.id;


--
-- Name: v_carrito; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW v_carrito AS
 SELECT ''::character varying(100) AS nombre_producto,
    0 AS cantidad,
    (0)::money AS precio;


ALTER TABLE v_carrito OWNER TO postgres;

--
-- Name: carrito id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY carrito ALTER COLUMN id SET DEFAULT nextval('carrito_id_seq'::regclass);


--
-- Name: productos id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY productos ALTER COLUMN id SET DEFAULT nextval('productos_id_seq'::regclass);


--
-- Name: usuario id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY usuario ALTER COLUMN id SET DEFAULT nextval('usuario_id_seq'::regclass);


--
-- Data for Name: carrito; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY carrito (id, id_producto, id_usuario, cantidad, estado) FROM stdin;
\.
COPY carrito (id, id_producto, id_usuario, cantidad, estado) FROM '$$PATH$$/2163.dat';

--
-- Name: carrito_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('carrito_id_seq', 5, true);


--
-- Data for Name: productos; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY productos (id, nombre, descripcion, precio, imagen, precioo) FROM stdin;
\.
COPY productos (id, nombre, descripcion, precio, imagen, precioo) FROM '$$PATH$$/2161.dat';

--
-- Name: productos_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('productos_id_seq', 8, true);


--
-- Data for Name: usuario; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY usuario (id, nombre, apellido, username, pass, rol) FROM stdin;
\.
COPY usuario (id, nombre, apellido, username, pass, rol) FROM '$$PATH$$/2159.dat';

--
-- Name: usuario_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('usuario_id_seq', 3, true);


--
-- Name: carrito carrito_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY carrito
    ADD CONSTRAINT carrito_pkey PRIMARY KEY (id);


--
-- Name: productos productos_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY productos
    ADD CONSTRAINT productos_pkey PRIMARY KEY (id);


--
-- Name: usuario usuario_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY usuario
    ADD CONSTRAINT usuario_pkey PRIMARY KEY (id);


--
-- Name: carrito id_producto; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY carrito
    ADD CONSTRAINT id_producto FOREIGN KEY (id_producto) REFERENCES productos(id);


--
-- Name: carrito id_usuario; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY carrito
    ADD CONSTRAINT id_usuario FOREIGN KEY (id_usuario) REFERENCES usuario(id);


--
-- PostgreSQL database dump complete
--

