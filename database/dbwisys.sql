--
-- PostgreSQL database dump
--

-- Dumped from database version 12.3
-- Dumped by pg_dump version 12.3

-- Started on 2020-09-08 20:00:19

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
-- TOC entry 212 (class 1259 OID 16460)
-- Name: AspNetRoleClaims; Type: TABLE; Schema: public; Owner: wisysadmin
--

CREATE TABLE public."AspNetRoleClaims" (
    "Id" integer NOT NULL,
    "RoleId" text NOT NULL,
    "ClaimType" text,
    "ClaimValue" text
);


ALTER TABLE public."AspNetRoleClaims" OWNER TO wisysadmin;

--
-- TOC entry 211 (class 1259 OID 16458)
-- Name: AspNetRoleClaims_Id_seq; Type: SEQUENCE; Schema: public; Owner: wisysadmin
--

ALTER TABLE public."AspNetRoleClaims" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."AspNetRoleClaims_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 203 (class 1259 OID 16415)
-- Name: AspNetRoles; Type: TABLE; Schema: public; Owner: wisysadmin
--

CREATE TABLE public."AspNetRoles" (
    "Id" text NOT NULL,
    "Name" character varying(256),
    "NormalizedName" character varying(256),
    "ConcurrencyStamp" text
);


ALTER TABLE public."AspNetRoles" OWNER TO wisysadmin;

--
-- TOC entry 214 (class 1259 OID 16475)
-- Name: AspNetUserClaims; Type: TABLE; Schema: public; Owner: wisysadmin
--

CREATE TABLE public."AspNetUserClaims" (
    "Id" integer NOT NULL,
    "UserId" text NOT NULL,
    "ClaimType" text,
    "ClaimValue" text
);


ALTER TABLE public."AspNetUserClaims" OWNER TO wisysadmin;

--
-- TOC entry 213 (class 1259 OID 16473)
-- Name: AspNetUserClaims_Id_seq; Type: SEQUENCE; Schema: public; Owner: wisysadmin
--

ALTER TABLE public."AspNetUserClaims" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."AspNetUserClaims_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 215 (class 1259 OID 16488)
-- Name: AspNetUserLogins; Type: TABLE; Schema: public; Owner: wisysadmin
--

CREATE TABLE public."AspNetUserLogins" (
    "LoginProvider" text NOT NULL,
    "ProviderKey" text NOT NULL,
    "ProviderDisplayName" text,
    "UserId" text NOT NULL
);


ALTER TABLE public."AspNetUserLogins" OWNER TO wisysadmin;

--
-- TOC entry 216 (class 1259 OID 16501)
-- Name: AspNetUserRoles; Type: TABLE; Schema: public; Owner: wisysadmin
--

CREATE TABLE public."AspNetUserRoles" (
    "UserId" text NOT NULL,
    "RoleId" text NOT NULL
);


ALTER TABLE public."AspNetUserRoles" OWNER TO wisysadmin;

--
-- TOC entry 217 (class 1259 OID 16519)
-- Name: AspNetUserTokens; Type: TABLE; Schema: public; Owner: wisysadmin
--

CREATE TABLE public."AspNetUserTokens" (
    "UserId" text NOT NULL,
    "LoginProvider" text NOT NULL,
    "Name" text NOT NULL,
    "Value" text
);


ALTER TABLE public."AspNetUserTokens" OWNER TO wisysadmin;

--
-- TOC entry 204 (class 1259 OID 16423)
-- Name: AspNetUsers; Type: TABLE; Schema: public; Owner: wisysadmin
--

CREATE TABLE public."AspNetUsers" (
    "Id" text NOT NULL,
    "UserName" character varying(256),
    "NormalizedUserName" character varying(256),
    "Email" character varying(256),
    "NormalizedEmail" character varying(256),
    "EmailConfirmed" boolean NOT NULL,
    "PasswordHash" text,
    "SecurityStamp" text,
    "ConcurrencyStamp" text,
    "PhoneNumber" text,
    "PhoneNumberConfirmed" boolean NOT NULL,
    "TwoFactorEnabled" boolean NOT NULL,
    "LockoutEnd" timestamp with time zone,
    "LockoutEnabled" boolean NOT NULL,
    "AccessFailedCount" integer NOT NULL
);


ALTER TABLE public."AspNetUsers" OWNER TO wisysadmin;

--
-- TOC entry 206 (class 1259 OID 16433)
-- Name: Categories; Type: TABLE; Schema: public; Owner: wisysadmin
--

CREATE TABLE public."Categories" (
    "CategoryId" integer NOT NULL,
    "Name" text,
    "Status" integer NOT NULL
);


ALTER TABLE public."Categories" OWNER TO wisysadmin;

--
-- TOC entry 205 (class 1259 OID 16431)
-- Name: Categories_CategoryId_seq; Type: SEQUENCE; Schema: public; Owner: wisysadmin
--

ALTER TABLE public."Categories" ALTER COLUMN "CategoryId" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Categories_CategoryId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 221 (class 1259 OID 16549)
-- Name: Inventories; Type: TABLE; Schema: public; Owner: wisysadmin
--

CREATE TABLE public."Inventories" (
    "InventoryId" integer NOT NULL,
    "Quantity" integer NOT NULL,
    "Status" integer NOT NULL,
    "ProductId" integer NOT NULL,
    "WarehouseId" integer NOT NULL
);


ALTER TABLE public."Inventories" OWNER TO wisysadmin;

--
-- TOC entry 220 (class 1259 OID 16547)
-- Name: Inventories_InventoryId_seq; Type: SEQUENCE; Schema: public; Owner: wisysadmin
--

ALTER TABLE public."Inventories" ALTER COLUMN "InventoryId" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Inventories_InventoryId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 219 (class 1259 OID 16534)
-- Name: Products; Type: TABLE; Schema: public; Owner: wisysadmin
--

CREATE TABLE public."Products" (
    "ProductId" integer NOT NULL,
    "Name" text,
    "Description" text,
    "BuyPrice" numeric NOT NULL,
    "SalePrice" numeric NOT NULL,
    "CreationDate" timestamp without time zone NOT NULL,
    "Status" integer NOT NULL,
    "CategoryId" integer NOT NULL
);


ALTER TABLE public."Products" OWNER TO wisysadmin;

--
-- TOC entry 218 (class 1259 OID 16532)
-- Name: Products_ProductId_seq; Type: SEQUENCE; Schema: public; Owner: wisysadmin
--

ALTER TABLE public."Products" ALTER COLUMN "ProductId" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Products_ProductId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 223 (class 1259 OID 16566)
-- Name: SaleProduct; Type: TABLE; Schema: public; Owner: wisysadmin
--

CREATE TABLE public."SaleProduct" (
    "SaleProductId" integer NOT NULL,
    "Quantity" integer NOT NULL,
    "SalePrice" numeric NOT NULL,
    "ProductId" integer NOT NULL,
    "WarehouseId" integer NOT NULL,
    "SaleId" integer NOT NULL
);


ALTER TABLE public."SaleProduct" OWNER TO wisysadmin;

--
-- TOC entry 222 (class 1259 OID 16564)
-- Name: SaleProduct_SaleProductId_seq; Type: SEQUENCE; Schema: public; Owner: wisysadmin
--

ALTER TABLE public."SaleProduct" ALTER COLUMN "SaleProductId" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."SaleProduct_SaleProductId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 208 (class 1259 OID 16443)
-- Name: Sales; Type: TABLE; Schema: public; Owner: wisysadmin
--

CREATE TABLE public."Sales" (
    "SaleId" integer NOT NULL,
    "SaleDate" timestamp without time zone NOT NULL,
    "Status" integer NOT NULL
);


ALTER TABLE public."Sales" OWNER TO wisysadmin;

--
-- TOC entry 207 (class 1259 OID 16441)
-- Name: Sales_SaleId_seq; Type: SEQUENCE; Schema: public; Owner: wisysadmin
--

ALTER TABLE public."Sales" ALTER COLUMN "SaleId" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Sales_SaleId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 210 (class 1259 OID 16450)
-- Name: Warehouses; Type: TABLE; Schema: public; Owner: wisysadmin
--

CREATE TABLE public."Warehouses" (
    "WarehouseId" integer NOT NULL,
    "Name" text,
    "Address" text,
    "Phone" text,
    "Status" integer NOT NULL
);


ALTER TABLE public."Warehouses" OWNER TO wisysadmin;

--
-- TOC entry 209 (class 1259 OID 16448)
-- Name: Warehouses_WarehouseId_seq; Type: SEQUENCE; Schema: public; Owner: wisysadmin
--

ALTER TABLE public."Warehouses" ALTER COLUMN "WarehouseId" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Warehouses_WarehouseId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 202 (class 1259 OID 16410)
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: wisysadmin
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO wisysadmin;

--
-- TOC entry 3776 (class 2606 OID 16467)
-- Name: AspNetRoleClaims PK_AspNetRoleClaims; Type: CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."AspNetRoleClaims"
    ADD CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY ("Id");


--
-- TOC entry 3762 (class 2606 OID 16422)
-- Name: AspNetRoles PK_AspNetRoles; Type: CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."AspNetRoles"
    ADD CONSTRAINT "PK_AspNetRoles" PRIMARY KEY ("Id");


--
-- TOC entry 3779 (class 2606 OID 16482)
-- Name: AspNetUserClaims PK_AspNetUserClaims; Type: CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."AspNetUserClaims"
    ADD CONSTRAINT "PK_AspNetUserClaims" PRIMARY KEY ("Id");


--
-- TOC entry 3782 (class 2606 OID 16495)
-- Name: AspNetUserLogins PK_AspNetUserLogins; Type: CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."AspNetUserLogins"
    ADD CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY ("LoginProvider", "ProviderKey");


--
-- TOC entry 3785 (class 2606 OID 16508)
-- Name: AspNetUserRoles PK_AspNetUserRoles; Type: CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY ("UserId", "RoleId");


--
-- TOC entry 3787 (class 2606 OID 16526)
-- Name: AspNetUserTokens PK_AspNetUserTokens; Type: CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."AspNetUserTokens"
    ADD CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY ("UserId", "LoginProvider", "Name");


--
-- TOC entry 3766 (class 2606 OID 16430)
-- Name: AspNetUsers PK_AspNetUsers; Type: CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."AspNetUsers"
    ADD CONSTRAINT "PK_AspNetUsers" PRIMARY KEY ("Id");


--
-- TOC entry 3769 (class 2606 OID 16440)
-- Name: Categories PK_Categories; Type: CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."Categories"
    ADD CONSTRAINT "PK_Categories" PRIMARY KEY ("CategoryId");


--
-- TOC entry 3794 (class 2606 OID 16553)
-- Name: Inventories PK_Inventories; Type: CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."Inventories"
    ADD CONSTRAINT "PK_Inventories" PRIMARY KEY ("InventoryId");


--
-- TOC entry 3790 (class 2606 OID 16541)
-- Name: Products PK_Products; Type: CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."Products"
    ADD CONSTRAINT "PK_Products" PRIMARY KEY ("ProductId");


--
-- TOC entry 3799 (class 2606 OID 16573)
-- Name: SaleProduct PK_SaleProduct; Type: CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."SaleProduct"
    ADD CONSTRAINT "PK_SaleProduct" PRIMARY KEY ("SaleProductId");


--
-- TOC entry 3771 (class 2606 OID 16447)
-- Name: Sales PK_Sales; Type: CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."Sales"
    ADD CONSTRAINT "PK_Sales" PRIMARY KEY ("SaleId");


--
-- TOC entry 3773 (class 2606 OID 16457)
-- Name: Warehouses PK_Warehouses; Type: CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."Warehouses"
    ADD CONSTRAINT "PK_Warehouses" PRIMARY KEY ("WarehouseId");


--
-- TOC entry 3760 (class 2606 OID 16414)
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- TOC entry 3764 (class 1259 OID 16594)
-- Name: EmailIndex; Type: INDEX; Schema: public; Owner: wisysadmin
--

CREATE INDEX "EmailIndex" ON public."AspNetUsers" USING btree ("NormalizedEmail");


--
-- TOC entry 3774 (class 1259 OID 16589)
-- Name: IX_AspNetRoleClaims_RoleId; Type: INDEX; Schema: public; Owner: wisysadmin
--

CREATE INDEX "IX_AspNetRoleClaims_RoleId" ON public."AspNetRoleClaims" USING btree ("RoleId");


--
-- TOC entry 3777 (class 1259 OID 16591)
-- Name: IX_AspNetUserClaims_UserId; Type: INDEX; Schema: public; Owner: wisysadmin
--

CREATE INDEX "IX_AspNetUserClaims_UserId" ON public."AspNetUserClaims" USING btree ("UserId");


--
-- TOC entry 3780 (class 1259 OID 16592)
-- Name: IX_AspNetUserLogins_UserId; Type: INDEX; Schema: public; Owner: wisysadmin
--

CREATE INDEX "IX_AspNetUserLogins_UserId" ON public."AspNetUserLogins" USING btree ("UserId");


--
-- TOC entry 3783 (class 1259 OID 16593)
-- Name: IX_AspNetUserRoles_RoleId; Type: INDEX; Schema: public; Owner: wisysadmin
--

CREATE INDEX "IX_AspNetUserRoles_RoleId" ON public."AspNetUserRoles" USING btree ("RoleId");


--
-- TOC entry 3791 (class 1259 OID 16596)
-- Name: IX_Inventories_ProductId; Type: INDEX; Schema: public; Owner: wisysadmin
--

CREATE INDEX "IX_Inventories_ProductId" ON public."Inventories" USING btree ("ProductId");


--
-- TOC entry 3792 (class 1259 OID 16597)
-- Name: IX_Inventories_WarehouseId; Type: INDEX; Schema: public; Owner: wisysadmin
--

CREATE INDEX "IX_Inventories_WarehouseId" ON public."Inventories" USING btree ("WarehouseId");


--
-- TOC entry 3788 (class 1259 OID 16598)
-- Name: IX_Products_CategoryId; Type: INDEX; Schema: public; Owner: wisysadmin
--

CREATE INDEX "IX_Products_CategoryId" ON public."Products" USING btree ("CategoryId");


--
-- TOC entry 3795 (class 1259 OID 16599)
-- Name: IX_SaleProduct_ProductId; Type: INDEX; Schema: public; Owner: wisysadmin
--

CREATE INDEX "IX_SaleProduct_ProductId" ON public."SaleProduct" USING btree ("ProductId");


--
-- TOC entry 3796 (class 1259 OID 16600)
-- Name: IX_SaleProduct_SaleId; Type: INDEX; Schema: public; Owner: wisysadmin
--

CREATE INDEX "IX_SaleProduct_SaleId" ON public."SaleProduct" USING btree ("SaleId");


--
-- TOC entry 3797 (class 1259 OID 16601)
-- Name: IX_SaleProduct_WarehouseId; Type: INDEX; Schema: public; Owner: wisysadmin
--

CREATE INDEX "IX_SaleProduct_WarehouseId" ON public."SaleProduct" USING btree ("WarehouseId");


--
-- TOC entry 3763 (class 1259 OID 16590)
-- Name: RoleNameIndex; Type: INDEX; Schema: public; Owner: wisysadmin
--

CREATE UNIQUE INDEX "RoleNameIndex" ON public."AspNetRoles" USING btree ("NormalizedName");


--
-- TOC entry 3767 (class 1259 OID 16595)
-- Name: UserNameIndex; Type: INDEX; Schema: public; Owner: wisysadmin
--

CREATE UNIQUE INDEX "UserNameIndex" ON public."AspNetUsers" USING btree ("NormalizedUserName");


--
-- TOC entry 3800 (class 2606 OID 16468)
-- Name: AspNetRoleClaims FK_AspNetRoleClaims_AspNetRoles_RoleId; Type: FK CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."AspNetRoleClaims"
    ADD CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES public."AspNetRoles"("Id") ON DELETE CASCADE;


--
-- TOC entry 3801 (class 2606 OID 16483)
-- Name: AspNetUserClaims FK_AspNetUserClaims_AspNetUsers_UserId; Type: FK CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."AspNetUserClaims"
    ADD CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;


--
-- TOC entry 3802 (class 2606 OID 16496)
-- Name: AspNetUserLogins FK_AspNetUserLogins_AspNetUsers_UserId; Type: FK CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."AspNetUserLogins"
    ADD CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;


--
-- TOC entry 3803 (class 2606 OID 16509)
-- Name: AspNetUserRoles FK_AspNetUserRoles_AspNetRoles_RoleId; Type: FK CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES public."AspNetRoles"("Id") ON DELETE CASCADE;


--
-- TOC entry 3804 (class 2606 OID 16514)
-- Name: AspNetUserRoles FK_AspNetUserRoles_AspNetUsers_UserId; Type: FK CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;


--
-- TOC entry 3805 (class 2606 OID 16527)
-- Name: AspNetUserTokens FK_AspNetUserTokens_AspNetUsers_UserId; Type: FK CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."AspNetUserTokens"
    ADD CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;


--
-- TOC entry 3807 (class 2606 OID 16554)
-- Name: Inventories FK_Inventories_Products_ProductId; Type: FK CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."Inventories"
    ADD CONSTRAINT "FK_Inventories_Products_ProductId" FOREIGN KEY ("ProductId") REFERENCES public."Products"("ProductId") ON DELETE CASCADE;


--
-- TOC entry 3808 (class 2606 OID 16559)
-- Name: Inventories FK_Inventories_Warehouses_WarehouseId; Type: FK CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."Inventories"
    ADD CONSTRAINT "FK_Inventories_Warehouses_WarehouseId" FOREIGN KEY ("WarehouseId") REFERENCES public."Warehouses"("WarehouseId") ON DELETE CASCADE;


--
-- TOC entry 3806 (class 2606 OID 16542)
-- Name: Products FK_Products_Categories_CategoryId; Type: FK CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."Products"
    ADD CONSTRAINT "FK_Products_Categories_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES public."Categories"("CategoryId") ON DELETE CASCADE;


--
-- TOC entry 3809 (class 2606 OID 16574)
-- Name: SaleProduct FK_SaleProduct_Products_ProductId; Type: FK CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."SaleProduct"
    ADD CONSTRAINT "FK_SaleProduct_Products_ProductId" FOREIGN KEY ("ProductId") REFERENCES public."Products"("ProductId") ON DELETE CASCADE;


--
-- TOC entry 3810 (class 2606 OID 16579)
-- Name: SaleProduct FK_SaleProduct_Sales_SaleId; Type: FK CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."SaleProduct"
    ADD CONSTRAINT "FK_SaleProduct_Sales_SaleId" FOREIGN KEY ("SaleId") REFERENCES public."Sales"("SaleId") ON DELETE CASCADE;


--
-- TOC entry 3811 (class 2606 OID 16584)
-- Name: SaleProduct FK_SaleProduct_Warehouses_WarehouseId; Type: FK CONSTRAINT; Schema: public; Owner: wisysadmin
--

ALTER TABLE ONLY public."SaleProduct"
    ADD CONSTRAINT "FK_SaleProduct_Warehouses_WarehouseId" FOREIGN KEY ("WarehouseId") REFERENCES public."Warehouses"("WarehouseId") ON DELETE CASCADE;


--
-- TOC entry 3943 (class 0 OID 0)
-- Dependencies: 3
-- Name: SCHEMA public; Type: ACL; Schema: -; Owner: wisysadmin
--

REVOKE ALL ON SCHEMA public FROM rdsadmin;
REVOKE ALL ON SCHEMA public FROM PUBLIC;
GRANT ALL ON SCHEMA public TO wisysadmin;
GRANT ALL ON SCHEMA public TO PUBLIC;


-- Completed on 2020-09-08 20:00:32

--
-- PostgreSQL database dump complete
--
