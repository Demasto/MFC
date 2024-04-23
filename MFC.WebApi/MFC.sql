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
    id integer NOT NULL,
    name character varying NOT NULL,
    path character varying
);


ALTER TABLE public.statements OWNER TO postgres;


ALTER TABLE public.statements ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.statements_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


CREATE TABLE public.statement_schemas (
    id integer NOT NULL,
    file_id integer NOT NULL,
    x numeric NOT NULL,
    y numeric NOT NULL,
    font_size integer DEFAULT 14,
    data_id character varying
);


ALTER TABLE public.statement_schemas OWNER TO postgres;

--
-- Name: file_schemas_file_schema_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.statement_schemas ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.statement_schemas_id_seq
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
    ADD CONSTRAINT statements_pkey PRIMARY KEY (id);


ALTER TABLE ONLY public.statement_schemas
    ADD CONSTRAINT statement_schemas_pkey PRIMARY KEY (id);


ALTER TABLE ONLY public.statement_schemas
    ADD CONSTRAINT statement_schemas_file_id_fkey FOREIGN KEY (file_id) REFERENCES public.statements(id) NOT VALID;
