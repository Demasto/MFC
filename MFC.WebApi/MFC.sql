--
-- PostgreSQL database dump
--

-- Dumped from database version 16.2 (Debian 16.2-1.pgdg120+2)
-- Dumped by pg_dump version 16.2

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: statements; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.statements (
    file_name character varying NOT NULL,
    file_path character varying,
    file_id integer NOT NULL
);


ALTER TABLE public.statements OWNER TO postgres;

--
-- Name: statements_file_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.statements ALTER COLUMN file_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.statements_file_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: file_schemas; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.file_schemas (
    file_id integer NOT NULL,
    x numeric NOT NULL,
    y numeric NOT NULL,
    font_size integer DEFAULT 14,
    data_id character varying,
    file_schema_id integer NOT NULL
);


ALTER TABLE public.file_schemas OWNER TO postgres;

--
-- Name: file_schemas_file_schema_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.file_schemas ALTER COLUMN file_schema_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.file_schemas_file_schema_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: statements  statements_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.statements
    ADD CONSTRAINT statements_pkey PRIMARY KEY (file_id);


--
-- Name: file_schemas file_schemas_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.file_schemas
    ADD CONSTRAINT file_schemas_pkey PRIMARY KEY (file_schema_id);


--
-- Name: file_schemas file_schemas_file_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.file_schemas
    ADD CONSTRAINT file_schemas_file_id_fkey FOREIGN KEY (file_id) REFERENCES public.statements(file_id) NOT VALID;


--
-- PostgreSQL database dump complete
--

